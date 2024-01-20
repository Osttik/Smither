using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Abstraction
{
    public interface IInteractConsumer { }

    public interface IInteractConsumer<T, R>: IInteractConsumer where T: IInteractable
    {
        public void ConsumeInteraction(T target, R result);
    }
}
