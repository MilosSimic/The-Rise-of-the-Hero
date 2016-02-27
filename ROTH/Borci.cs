using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROTH
{
    public class Borci
    {
        private int brojStrelaca;
        private int brojMacevalaca;
        private const int jacinaStrelaca = 2;
        private const int jacinaMacevalaca = 3;

        public Borci()
        {
        }

        public Borci(int bs, int bm)
        {
            brojStrelaca = bs;
            brojMacevalaca = bm;
        }

        public int BROJSTRELACA
        {
            get { return brojStrelaca; }
            set { brojStrelaca = value; }
        }

        public void smanjiBrojstrelaca(int brojPoginulih)
        {
            if (brojPoginulih > brojStrelaca)
            {
                brojStrelaca = 0;
            }
            else
            {
                brojStrelaca -= brojPoginulih;
            }
        }

        public void smanjiBrojMacevalaca(int brojPoginulih)
        {
            if (brojPoginulih > brojMacevalaca)
            {
                brojMacevalaca = 0;
            }
            else
            {
                brojMacevalaca -= brojPoginulih;
            }
        }

        public int BROJMACEVALACA
        {
            get { return brojMacevalaca; }
            set { brojMacevalaca = value; }
        }
    }
}
