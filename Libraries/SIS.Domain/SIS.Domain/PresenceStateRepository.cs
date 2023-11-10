#if JARI
using System.Collections.Generic;
using SIS.Domain;

public interface IPresenceStateRepository
{
    Dictionary<int, PresenceState> PresenceStates { get; }

    Dictionary<int, PresenceState> RefreshPresenceStates();

    void Insert(PresenceState presenceState);

    void Update(PresenceState presenceState);

    void Delete(PresenceState presenceState);

    bool Exists(PresenceState presenceState);
}
#endif