using PrFinal_namespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace PrFinal_namespace
{
    public class Tarjeta
    {
        Objeto miIndividuo;
        VisualElement tarjetaRoot;

        Label labelName;

        public Tarjeta(VisualElement tarjetaRoot, Objeto miIndividuo)
        {
            this.tarjetaRoot = tarjetaRoot;
            this.miIndividuo = miIndividuo;

            labelName = tarjetaRoot.Q<Label>("Nombre");

            UpdateUI();

            miIndividuo.Cambio += UpdateUI;
        }

        public void UpdateUI()
        {
            labelName.text = miIndividuo.Name;
        }
    }
}
