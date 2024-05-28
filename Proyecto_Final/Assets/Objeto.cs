using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrFinal_namespace
{
    public class Objeto
    {
        public event Action Cambio;

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    Cambio?.Invoke();
                }
            }
        }

        public Objeto(string name)
        {
            this.name = name;
        }
    }
}
