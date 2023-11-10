#if JARI
using System.Collections.Generic;
using SIS.Domain;

public interface IPresenceRepository
{
    Dictionary<int, Presence> Presences { get; }
    
    Dictionary<int, Presence> RefreshPresences();

    void Insert(Presence presence);

    void Update(Presence presence);

    void Delete(Presence presence);

    bool Exists(Presence presence);
}
#endif