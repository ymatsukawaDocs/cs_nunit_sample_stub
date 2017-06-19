using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppForUnitTest.Model
{
    public interface IRoom
    {
        Boolean IsBrightRoom();
    }

    public class Room : IRoom
    {
        public Room(ILight light)
        {
            this.light = light;
        }

        public Boolean IsBrightRoom()
        {
            if(this.light.Power)
            {
                return true;
            }
            return false;
        }

        private ILight light;
    }
}
