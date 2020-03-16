using FFProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFProject.Repository
{
    public interface IFootball
    {
        List<Roster> Rosters { get;}

        public void AddPlayer(Roster roster);

        Roster GetPlayerByName(string name);
        Roster GetPlayerByID(int id);
        int Edit(Roster roster);
        int Delete(int id);

    }
}
