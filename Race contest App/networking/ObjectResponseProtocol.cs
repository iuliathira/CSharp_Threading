using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using race.model;

namespace networking.response
{
    public interface Response
    {
    }
    [Serializable]
    public class OKResponse : Response
    {
        
    }
    
    [Serializable]
    public class ErrorResponse : Response
    {
        private string message;

        public ErrorResponse(string message)
        {
            this.message = message;
        }
        public virtual string Message
        {
            get
            {
                return message;
            }
        }
    }

    [Serializable]
    public class GetContestantsResponse : Response
    {
        private List<ContestantDTO> contestantDTOs;
        public GetContestantsResponse(List<ContestantDTO> conts)
        {
            this.contestantDTOs = conts;
        }

        public List<ContestantDTO> ContestantDTOs
        {
            get
            {
                return contestantDTOs;
            }
        }
    }

    [Serializable]
    public class GetRacesResponse : Response
    {
        private List<RaceDTO> races;
        public GetRacesResponse(List<RaceDTO> r)
        {
            this.races = r;
        }

        public List<RaceDTO> RaceDTOs
        {
            get
            {
                return this.races;
            }
        }

    }
    
    public interface UpdateResponse : Response
    {
     
    }

    [Serializable]
    public class IncreaseNoPResponse : UpdateResponse
    {
        RaceDTO race;
        public RaceDTO Race
        {
            get
            {
                return this.race;
            }
        }

       

        public IncreaseNoPResponse(RaceDTO r)
        {
            this.race = r;
        }


    } 


   
}
