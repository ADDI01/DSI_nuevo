using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace PrFinal_namespace
{
    public class NewBehaviourScript : MonoBehaviour
    {
        VisualElement root;
        StyleSheet stylesheet;

        Button albumButton;
        TextField cambioNombre;

        VisualElement plantillaImg;
        VisualElement plantilla;
        VisualElement img1;
        VisualElement img2;
        VisualElement img3;
        VisualElement img4;

        Sprite idle;
        Sprite mouth;
        Sprite back;
        Sprite side;

        Objeto individuo;

        private void OnEnable()
        {
            root = GetComponent<UIDocument>().rootVisualElement;

            albumButton = root.Q<Button>("Album");

            albumButton.RegisterCallback<ClickEvent>(IrAlAlbum);
        }

        void IrAlAlbum(ClickEvent e)
        {
            root.Clear();
            VisualTreeAsset albumTemplate = Resources.Load<VisualTreeAsset>("Album");
            stylesheet = Resources.Load<StyleSheet>("Stylesheets/stylesheet2");

            VisualElement fondoAlbum = albumTemplate.Instantiate();
            root.Add(fondoAlbum);
            fondoAlbum.styleSheets.Add(stylesheet);
                
            plantilla = root.Q<VisualElement>("TarjetaPersonalizada");
            plantillaImg = plantilla.Q<VisualElement>("img");
            cambioNombre = root.Q<TextField>("nombre");

            individuo = new Objeto("hola");
            Tarjeta tarjetaPrueba = new Tarjeta(plantilla, individuo);

            img1 = root.Q<VisualElement>("Tranquilo");
            img2 = root.Q<VisualElement>("Gloton");
            img3 = root.Q<VisualElement>("Enfadado");
            img4 = root.Q<VisualElement>("Observador");

            idle = Resources.Load<Sprite>("Sprites/Tranquilo");
            mouth = Resources.Load<Sprite>("Sprites/Gloton");
            back = Resources.Load<Sprite>("Sprites/Enfadado");
            side = Resources.Load<Sprite>("Sprites/Observador");

            img1.RegisterCallback<ClickEvent>(CambioImgIdle);
            img2.RegisterCallback<ClickEvent>(CambioImgMouth);
            img3.RegisterCallback<ClickEvent>(CambioImgBack);
            img4.RegisterCallback<ClickEvent>(CambioImgSide);

            cambioNombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
        }
        void CambioNombre(ChangeEvent<string> evt)
        {
            individuo.Name = evt.newValue;
        }

        void CambioImgIdle(ClickEvent evt)
        {
            plantillaImg.style.backgroundImage = new StyleBackground(idle);
        }

        void CambioImgMouth(ClickEvent evt)
        {
            plantillaImg.style.backgroundImage = new StyleBackground(mouth);
        }

        void CambioImgBack(ClickEvent evt)
        {
            plantillaImg.style.backgroundImage = new StyleBackground(back);
        }

        void CambioImgSide(ClickEvent evt)
        {
            plantillaImg.style.backgroundImage = new StyleBackground(side);
        }
    }
}
