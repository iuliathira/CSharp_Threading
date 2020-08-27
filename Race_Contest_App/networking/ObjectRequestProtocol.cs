using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networking.request
{

    public interface Request
    {

    }

    [Serializable]
    public class LoginRequest : Request
    {
        private OfficePersonDTO userDTO;
        public LoginRequest(OfficePersonDTO personDTO)
        {
            this.userDTO = personDTO;
        }

        public OfficePersonDTO OfficePersonDTO()
        {
                        
                return this.userDTO;
            
        }
    }

    [Serializable]
    public class LogoutRequest : Request
    {
        private OfficePersonDTO userDTO;
        public LogoutRequest(OfficePersonDTO personDTO)
        {
            this.userDTO = personDTO;
        }

        public OfficePersonDTO OfficePersonDTO()
        {
            
                return this.userDTO;
            
        }
    }

    [Serializable]
    public class SaveRegistrationRequest : Request
    {
        RegistrationDTO registrationDTO;
        public SaveRegistrationRequest(RegistrationDTO reg)
        {
            this.registrationDTO = reg;
        }

        public virtual RegistrationDTO RegistrationDTO
        {
            get
            {
                return this.registrationDTO;
            }
        }
    }

    [Serializable]
    public class GetRacesRequest : Request
    {
        public GetRacesRequest() { }
    }

    [Serializable]
    public class GetContestantsRequest : Request
    {
        public GetContestantsRequest() { }
    }

}
