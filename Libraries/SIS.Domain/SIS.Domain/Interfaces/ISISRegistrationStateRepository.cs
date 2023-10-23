namespace SIS.Domain.Interfaces
{
    public interface ISISRegistrationStateRepository
    {
        public Dictionary<string, RegistrationState> RegistrationStates { get; }

        public Dictionary<string, RegistrationState> RefreshRegistrationStates();
        public bool Exists(RegistrationState registrationState);
        public void Insert(RegistrationState registrationState);
        public void Update(RegistrationState registrationState);
        public void Delete(RegistrationState registrationState);
    }
}