using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lavirint;
using ROTF;

namespace ROTH
{
    class AI
    {
        /// <summary>
        /// Implementacija minimax algoritma. Odredjivanje najboljeg poteza Determines the best move for the current 
        /// board by igrajuci svaku mogucu kombijaciju pomeranja dok se igra ne zavrsi.
        /// </summary>
        public static State GetBestMove(DisplayPanel displayPanel, Hero hero)
        {
            State bestState = null;
            //prebaci sva mogica polja heroja u listu 
            List<State> openSpaces = displayPanel.pocetnoStanje.mogucaSledecaStanja(hero);

            //prolazi kroz listu praznih polja
            for (int i = 0; i < openSpaces.Count; i++)
            {
                //uzme trenutnu poziciju(stanje)
                State newSpace = openSpaces[i];
                                                            /*skontati sta ovde....*/
                if (displayPanel.Winner() == Pobednik.Niko /*&& newBoard.OpenSquares.Count > 0*/)
                {
                    State tempMove = GetBestMove(newBoard, ((Hero)(-(int)p)));  //a little hacky, inverts the current player
                    newSpace.Rank = tempMove.Rank;
                }
                else
                {
                    if (displayPanel.Winner() == Pobednik.Niko)
                    {
                        displayPanel.Rank = 0;
                    }
                    else if (displayPanel.Winner() == Pobednik.Covek)
                    {
                        displayPanel.Rank = -1;
                    }
                    else if (displayPanel.Winner() == Pobednik.Masina)
                    {
                        displayPanel.Rank = 1;
                    }
                }

                //Ako je novo stanje bolje od prethodnog, uzmi ga
                /*if (bestState == null ||
                   (p == Osvajac.Covek && newSpace.Rank < bestState.Rank) ||
                   (p == Osvajac.Masina && newSpace.Rank > ((Space)bestSpace).Rank))
                {
                    bestState = newSpace;
                }*/
            }

            return bestState;
        }
    }
}
