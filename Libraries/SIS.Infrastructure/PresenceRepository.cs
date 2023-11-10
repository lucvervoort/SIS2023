#if JARI
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIS.Infrastructure
{
    public class EFPresenceRepository : IPresenceRepository
    {
        private readonly ILogger<EFPresenceRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<int, Presence> _presences;

        public Dictionary<int, Presence> Presences
        {
            get
            {
                if (_presences != null) return _presences;
                return RefreshPresences();
            }
        }

        public EFPresenceRepository(ILogger<EFPresenceRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all presences up front
            RefreshPresences();
        }

        public Dictionary<int, Presence> RefreshPresences()
        {
            _presences = new Dictionary<int, Presence>();
            var dbPresences = _context.Presences.Include(p => p.Person).Include(p => p.PresenceState).ToList();
            foreach (var presence in dbPresences)
            {
                var p = new Presence
                {
                    PresenceId = presence.PresenceId,
                    OfficialCode = presence.OfficialCode,
                    Qrcode = presence.Qrcode,
                    PresenceStateId = presence.PresenceStateId,
                    PersonId = presence.PersonId,
                    AutoTimeCreation = presence.AutoTimeCreation,
                    AutoTimeUpdate = presence.AutoTimeUpdate,
                    AutoUpdateCount = presence.AutoUpdateCount,
                    IsDeleted = presence.IsDeleted,
                    Person = new Person
                    {
                        // Hier kun je de eigenschappen van de persoon instellen op basis van presence.Person
                        // Voorbeeld: FirstName = presence.Person.FirstName, LastName = presence.Person.LastName, enz.
                    },
                    PresenceState = new PresenceState
                    {
                        // Hier kun je de eigenschappen van de PresenceState instellen op basis van presence.PresenceState
                        // Voorbeeld: Name = presence.PresenceState.Name, Description = presence.PresenceState.Description, enz.
                    }
                };
                _presences.Add(p.PresenceId, p);
            }
            return _presences;
        }

        public void Insert(Presence presence)
        {
            if (_presences.ContainsKey(presence.PresenceId))
                return;

            var efPresence = new EFRepository.Models.Presence
            {
                OfficialCode = presence.OfficialCode,
                Qrcode = presence.Qrcode,
                PresenceStateId = presence.PresenceStateId,
                PersonId = presence.PersonId,
                AutoTimeCreation = DateTime.Now,
                AutoTimeUpdate = DateTime.Now,
                AutoUpdateCount = 0,
                IsDeleted = false
            };

            var addedPresence = _context.Presences.Add(efPresence).Entity;
            var count = _context.SaveChanges();

            presence.PresenceId = addedPresence.PresenceId;

            _presences.Add(presence.PresenceId, presence);
        }

        public void Update(Presence presence)
        {
            if (_presences.ContainsKey(presence.PresenceId))
            {
                var efPresence = _context.Presences.Find(presence.PresenceId);
                if (efPresence != null)
                {
                    efPresence.OfficialCode = presence.OfficialCode;
                    efPresence.Qrcode = presence.Qrcode;
                    efPresence.PresenceStateId = presence.PresenceStateId;
                    efPresence.PersonId = presence.PersonId;
                    efPresence.AutoTimeUpdate = DateTime.Now;
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(Presence presence)
        {
            if (_presences.ContainsKey(presence.PresenceId))
            {
                var efPresence = _context.Presences.Find(presence.PresenceId);
                if (efPresence != null)
                {
                    _context.Presences.Remove(efPresence);
                    _context.SaveChanges();
                }
                _presences.Remove(presence.PresenceId);
            }
        }

        public bool Exists(Presence presence)
        {
            return _presences.ContainsKey(presence.PresenceId);
        }
    }
}
#endif