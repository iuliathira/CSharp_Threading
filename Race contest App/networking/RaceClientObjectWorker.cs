using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services;
using System.Threading;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using race.model;
using networking.response;
using networking.request;
using System.Net;
namespace networking
{
    public class RaceClientWorker : IClient
    {
        private IServer server;
        private TcpClient connection;

        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;
        private string username;

        public RaceClientWorker(IServer srv, TcpClient conn)
        {
            this.server = srv;
            this.connection = conn;
            try
            {
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            }catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public virtual void run()
        {
            while (connected)
            {
                try
                {
                    object request = formatter.Deserialize(stream);
                    object response = handleRequest((Request) request);
                    Console.WriteLine("worker request: " + request.ToString());
                    if (response != null)
                    {
                        Console.WriteLine("worker response: " + response.ToString());
                        sendResponse((Response)response);
                    }
                }catch(Exception e)
                {
                    Console.WriteLine
                        (e.StackTrace);
                }

                try
                {
                    Thread.Sleep(1000);
                }catch(Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            try
            {
                stream.Close();
                connection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }

       private Response handleRequest(Request request)
        {
            Console.WriteLine("Handle request pentru..." + request);
            Response response = null;
            if (request is LoginRequest)
            {
                Console.WriteLine("Login request...");
                LoginRequest loginRequest = (LoginRequest)request;
                OfficePersonDTO userDTO = loginRequest.OfficePersonDTO();
                OfficePers pers = DTOUtils.getFromDTO(userDTO);
                try
                {
                    lock (server)
                    {
                        server.login(pers, this);
                        username = pers.Username;
                    }
                    return new OKResponse();
                }catch(RaceException ex)
                {
                    connected = false;
                    return new ErrorResponse(ex.Message);
                }
            }

            if (request is LogoutRequest)
            {
                Console.WriteLine("Logout request...");
                LogoutRequest logReq = (LogoutRequest)request;
                OfficePersonDTO dTO = logReq.OfficePersonDTO();
                OfficePers user = DTOUtils.getFromDTO(dTO);
                try
                {
                    lock (server)
                    {
                        server.logout(user, this);
                    }
                    connected = false;
                    return new OKResponse();

                }catch(RaceException ex)
                {
                    return new ErrorResponse(ex.Message);
                }
            }

            if(request is GetRacesRequest)
            {
                Console.WriteLine("Get all races request");
                GetRacesRequest req = (GetRacesRequest)request;
                try
                {
                    IList<Race> races = new List<Race>();
                    lock (server)
                    {
                        races = server.getAllRaces();
                    }
                    IList<RaceDTO> raceDTOs = new List<RaceDTO>();
                    foreach(Race r in races)
                    {
                        RaceDTO raceDTO = DTOUtils.getDTO(r);
                        raceDTOs.Add(raceDTO);
                    }
                    return new GetRacesResponse((List<RaceDTO>)raceDTOs);
                }catch(Exception ex)
                {
                    throw new RaceException(ex.Message);
                }
            }

            if(request is GetContestantsRequest)
            {
                GetContestantsRequest req = (GetContestantsRequest)request;
                try
                {
                    IList<Contestant> contestants = new List<Contestant>();
                    lock (server)
                    {
                        contestants = server.getAllContestants();
                    }
                    IList<ContestantDTO> contestantDTOs = new List<ContestantDTO>();
                    foreach(Contestant c in contestants)
                    {
                        ContestantDTO dTO = DTOUtils.getDTO(c);
                        contestantDTOs.Add(dTO);
                    }
                    return new GetContestantsResponse((List<ContestantDTO>)contestantDTOs);
                }catch(Exception e)
                {
                    throw new RaceException(e.Message);
                }
            }

            if (request is SaveRegistrationRequest)
            {
                Console.WriteLine("Saving registration...");
                SaveRegistrationRequest req = (SaveRegistrationRequest)request;
                RegistrationDTO registrationDTO = req.RegistrationDTO;
                try
                {
                    lock (server)
                    {
                        server.addContestant(registrationDTO.Contestant.Name, registrationDTO.Contestant.Engine, registrationDTO.Contestant.Team, username);
                    }
                    return new OKResponse();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            return response;
        }



        private void sendResponse(Response response)
        {
            Console.WriteLine("sending response " + response);
            formatter.Serialize(stream, response);
            stream.Flush();
        }

        public void increaseNoContestants(Race race)
        {
            Console.WriteLine("aici");
            RaceDTO dTO = DTOUtils.getDTO(race);
            try
            {
                sendResponse(new IncreaseNoPResponse(dTO));
            }catch (Exception e)
            {
                throw new RaceException("Sending error..." + e.Message);
            }
        }
    }
}
