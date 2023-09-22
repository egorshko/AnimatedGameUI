using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Rendering;

namespace Assets.Scripts
{
    internal interface IExecute
    {
        void Execute(float deltatime);
    }
}
