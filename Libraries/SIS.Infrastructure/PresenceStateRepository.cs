#if JARI
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using SIS.Domain;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;

namespace SIS.Infrastructure
{
    public class EFPresenceStateRepository : IPresenceStateRepository
    {
        private readonly SisDbContext _context;
        private Dictionary<int, PresenceState> _presenceStates;

        public Dictionary<int, PresenceState> PresenceStates
        {
            get
            {
                if (_presenceStates != null) return _presenceStates;
                return RefreshPresenceStates();
            }
        }

        public EFPresenceStateRepository(SisDbContext context)
        {
            _context = context;
            RefreshPresenceStates();
        }

        public Dictionary<int, PresenceState> RefreshPresenceStates()
        {
            _presenceStates = new Dictionary<int, PresenceState>();
            var dbPresenceStates = _context.PresenceStates.ToList();
            
            foreach (var presenceState in dbPresenceStates)
            {
                _presenceStates[presenceState.PresenceStateId] = new PresenceState
                {
                    PresenceStateId = presenceState.PresenceStateId,
                    Name = presenceState.Name,
                    Description = presenceState.Description,
                    AutoTimeCreation = presenceState.AutoTimeCreation,
                    AutoTimeUpdate = presenceState.AutoTimeUpdate,
                    AutoUpdateCount = presenceState.AutoUpdateCount,
                    IsDeleted = presenceState.IsDeleted
                };
            }
            
            return _presenceStates;
        }

        public void Insert(PresenceState presenceState)
        {
            if (PresenceStates.Any(ps => ps.Value.Name == presenceState.Name))
                return;

            var efPresenceState = new EFRepository.Models.PresenceState
            {
                Name = presenceState.Name,
                Description = presenceState.Description,
                AutoTimeCreation = DateTime.Now,
                AutoTimeUpdate = DateTime.Now,
                AutoUpdateCount = 0,
                IsDeleted = false
            };

            var addedPresenceState = _context.PresenceStates.Add(efPresenceState).Entity;
            var count = _context.SaveChanges();

            presenceState.PresenceStateId = addedPresenceState.PresenceStateId;
            _presenceStates[presenceState.PresenceStateId] = presenceState;
        }

        public void Update(PresenceState presenceState)
        {
            if (PresenceStates.TryGetValue(presenceState.PresenceStateId, out var existingPresenceState))
            {
                var efPresenceState = _context.PresenceStates.Find(presenceState.PresenceStateId);
                if (efPresenceState != null)
                {
                    efPresenceState.Name = presenceState.Name;
                    efPresenceState.Description = presenceState.Description;
                    efPresenceState.AutoTimeUpdate = DateTime.Now;
                    _context.SaveChanges();
                }

                existingPresenceState.Name = presenceState.Name;
                existingPresenceState.Description = presenceState.Description;
            }
        }

        public void Delete(PresenceState presenceState)
        {
            if (PresenceStates.ContainsKey(presenceState.PresenceStateId))
            {
                var efPresenceState = _context.PresenceStates.Find(presenceState.PresenceStateId);
                if (efPresenceState != null)
                {
                    _context.PresenceStates.Remove(efPresenceState);
                    _context.SaveChanges();
                }
                _presenceStates.Remove(presenceState.PresenceStateId);
            }
        }

        public bool Exists(PresenceState presenceState)
        {
            return PresenceStates.ContainsKey(presenceState.PresenceStateId);
        }
    }
}
#endif