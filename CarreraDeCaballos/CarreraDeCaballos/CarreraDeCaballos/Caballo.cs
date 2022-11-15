using System;
using System.Collections.Generic;
using System.Text;

namespace CarreraDeCaballos
{
    class Caballo
    {

        private int posicion;
        private int meta;
        private bool haGanado=false;

        public bool HaGanado { get { return haGanado; } }
        public int Posicion { get { return posicion; } set { value = posicion; } }

            public Caballo(int meta)
                    {
            posicion = 0;
            this.meta = meta;
        }

        public void correrPosicion()
        {
            var random = new Random();
            int r = random.Next(1, 4);
            posicion += r;
            if(posicion>= meta)
            {

                haGanado = true;
            }
        }
    }
}
