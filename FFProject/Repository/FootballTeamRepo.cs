using FFProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFProject.Repository
{
    public class FootballTeamRepo : IFootball
    {
        private ApplicationDbContext contextRoster;
        public List<Roster> Rosters { get { return contextRoster.Rosters.Include("Owner").ToList(); } }

        public FootballTeamRepo(ApplicationDbContext appDbContext)
        {
            contextRoster = appDbContext;
        }

        public void AddPlayer(Roster roster)
        {
            //contextRoster.Users.Add(roster.Owner); Not Loading Owners Correctly
            contextRoster.Rosters.Add(roster);
            contextRoster.SaveChanges();
        }
        public Roster GetPlayerByName(string name)
        {
            Roster roster;
            roster = contextRoster.Rosters.First(s => s.PlayerName == name);
            return roster;
        }

        public Roster GetPlayerByID(int id)
        {
            return contextRoster.Rosters.First(a => a.RosterID == id);
        }
        public int Edit(Roster roster)
        {
            contextRoster.Rosters.Update(roster);
            return contextRoster.SaveChanges();
        }

        public int Delete(int id)
        {
            var rosterDB = contextRoster.Rosters.First(a => a.RosterID == id);
            contextRoster.Remove(rosterDB);
            return contextRoster.SaveChanges();
        }
    }
}
