using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using services;
using System.Net.Sockets;
using System.Runtime.Serialization;
using networking.response;
using networking.request;
using System.Threading;
using race.model;

namespace networking
{
    public class ServerProxy : IServer 
    {
        private string host;
        private int port;

        private IClient client;
        private NetworkStream stream;

        private IFormatter formatter;
        private TcpClient connection;

        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle eventWaitHandle;

        public ServerProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            responses = new Queue<Response>();
        }


        public void login(OfficePers user, IClient client)
        {
            initializeConnection();
            OfficePersonDTO udto = DTOUtils.getDTO(user);
            sendRequest(new LoginRequest(udto));
            Response response = readResponse();
            if(response is OKResponse)
            {
                this.client = client;
                return;
            }
            if(response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new RaceException(err.Message);
            }
        }

        private Response readResponse()
        {
            Response response = null;
            try
            {
                eventWaitHandle.WaitOne();
                lock (responses)
                {
                    response = responses.Dequeue();
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }

        private void sendRequest(Request request)
        {
            try
            {
                formatter.Serialize(stream, request);
                stream.Flush();
                Console.WriteLine("Request sent: " + request);
            }
            catch (Exception e)
            {
                throw new RaceException("Error sending object: " + e.Message);
            }

        }

        public void addContestant(string name, int engine, string team,string username)
        {
            Contestant c = new Contestant(name, team, engine);
            Race r = new Race(engine);
            ContestantDTO contestantDTO = new ContestantDTO(name, team, engine);
            RaceDTO raceDTO = new RaceDTO(engine);
            RegistrationDTO registrationDTO = new RegistrationDTO(contestantDTO, raceDTO);
            sendRequest(new SaveRegistrationRequest(registrationDTO));
            Response response = readResponse();
            if(response is ErrorResponse)
            {
                ErrorResponse error = (ErrorResponse)response;
                throw new RaceException(error.Message);
            }
        }

        public List<Contestant> getAllContestants()
        {
            sendRequest(new GetContestantsRequest());
            Response response = readResponse();
            if (response is GetContestantsResponse)
            {
                GetContestantsResponse resp = (GetContestantsResponse)response;
                
                IList<Contestant> contestants = new List<Contestant>();
                foreach(ContestantDTO c in resp.ContestantDTOs)
                {
                    contestants.Add(DTOUtils.getFromDTO(c));
                }
                return (List<Contestant>)contestants;
            }
            return null;
        }

        public List<Race> getAllRaces()
        {
            sendRequest(new GetRacesRequest());
            Response response = readResponse();
            if(response is GetRacesResponse)
            {
                GetRacesResponse resp = (GetRacesResponse)response;
                
                IList<Race> races = new List<Race>();
                foreach(RaceDTO race in resp.RaceDTOs)
                {
                    races.Add(DTOUtils.getFromDTO(race));
                }
                return (List<Race>)races;
            }
            return null;
        }

        public List<Contestant> getContestantsByTeam(string team)
        {
            sendRequest(new GetContestantsRequest());
            Response response = readResponse();
            if (response is GetContestantsResponse)
            {
                GetContestantsResponse resp = (GetContestantsResponse)response;

                IList<Contestant> contestants = new List<Contestant>();
                foreach (ContestantDTO c in resp.ContestantDTOs)
                {
                    if(c.Team.Equals(team))
                        contestants.Add(DTOUtils.getFromDTO(c));
                }
                return (List<Contestant>)contestants;
            }
            return null;
        }

        public List<Race> getRacesByEngine(int engine)
        {
            sendRequest(new GetRacesRequest());
            Response response = readResponse();
            if (response is GetRacesResponse)
            {
                GetRacesResponse resp = (GetRacesResponse)response;
                IList<Race> races = new List<Race>();
                foreach(RaceDTO r in resp.RaceDTOs)
                {
                    if (r.Engine == engine)
                        races.Add(DTOUtils.getFromDTO(r));
                }
                return (List<Race>)races;
            }
            return null;
        }

        public void logout(OfficePers user, IClient client)
        {
            OfficePersonDTO officePersonDTO = DTOUtils.getDTO(user);
            sendRequest(new LogoutRequest(officePersonDTO));
            Response response = readResponse();
            closeConnection();
            if(response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new RaceException(err.Message);
            }
        }

        public void handleUpdate(UpdateResponse update)
        {
            if (update is IncreaseNoPResponse)
            {
                IncreaseNoPResponse incResp = (IncreaseNoPResponse)update;
                Race r = DTOUtils.getFromDTO(incResp.Race);
               
                try
                {
                    client.increaseNoContestants(r);
                }catch(Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

        }

        private void closeConnection()
        {
            finished = true;
            try
            {
                stream.Close();
                //output.close();
                connection.Close();
                eventWaitHandle.Close();
                client = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

       
        

        private void initializeConnection()
        {
            try
            {
                connection = new TcpClient(host, port);
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                finished = false;
                eventWaitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        private void startReader()
        {
            Thread tw = new Thread(run);
            tw.Start();
        }
        public void run()
        {
            while (!finished)
            {
                try
                {
                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("response received " + response);
                    if (response is UpdateResponse)
                    {
                        handleUpdate((UpdateResponse)response);
                    }
                    else
                    {

                        lock (responses)
                        {


                            responses.Enqueue((Response)response);

                        }
                    }
                    eventWaitHandle.Set();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error " + e);
                }

            }
        }

    }
}
