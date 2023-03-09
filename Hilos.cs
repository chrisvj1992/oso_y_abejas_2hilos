using System;
using System.Threading;

/**
 * el oso y las abejas
 * 
 * hay un oso
 * el oso esta dormido
 * se despierta hasta que puede comer
 * existen n abejas 
 * ejemplo 10 abejas y un tarro de miel, el tarro originalmente esta vacio
 * al tarro le caben 10 unidades de mil
 * cada abeja hace de forma aleatorea n unidades de miel
 * cuando se llena el oso despierta, las abejas dejan de trabajar 
 * el oso vacia el tarro, se vuelve a dormir y las abejas vuelven a producir miel
 * las abejas son circulares, si por ejemplo hay 10 abejas empieza en el indice 0
 * y pasa hasta la 9 
 * las abejas llenan el tarro en orden
 * una vez que acaba la ultima la primera vuelve a empezar
 * cada abeja genera unidades aleatoreas de miel dependiendo 
 * la capacidad del tarro de miel
 * poner textos para indicar si funciona ejemplo:
 *      abeja 1 ha dejado n miel
 *      abeja 2 ha dejado n miel
 *      el tarro se ha llenado
 *      el oso se ha despertado
 *      el oso ha vaciado el tarro
 *      la abeja 1 ha dejado n miel
 * podemos usar sleep, para que la salida de texto no sea de golpe
 * no usar sleep para sincronizar los hilos
 * 
 * si estamos depurando el hilo del oso, el hilo de
 * las abejas siguen trabajando
 * 
 * los hilos siguen ejecutandose aunque esten en modo depuracion
 * 
 * tener cuidado al depurar, buscar en google como
 * depurar hilos
 *  
 * 
 */

namespace ActivHilos
{
    internal class Hilos
    {
        private int tarro = 0;
        private int capacidad = 15;
        private int[] abejas;



        public int terminado = 0;

        int numVecesOsoEchoLaPapa =0;
        public Hilos()
        {
            Random r = new Random();
            abejas = new int[10];
            for(int i=0;i< abejas.Length;i++) 
            {
                abejas[i] = r.Next(1,5);
            }   


            Thread t = new Thread(Abejas);
            t.Start();

            Thread t1 = new Thread(Oso);
            t1.Start();
        }

        bool osoPuedeComer = false;
        void Abejas()
        {
            int i = 0;
            while (numVecesOsoEchoLaPapa < 3)
            {
                    tarro += abejas[i];

                    Console.WriteLine("Abeja {0} produce {1}.  Tarro {2}", i, abejas[i], tarro);

                    if (tarro >= capacidad)
                    {
                        Console.WriteLine("Tarro Lleno");

                        numVecesOsoEchoLaPapa++;

                        osoPuedeComer = true;
                        while (osoPuedeComer == true) { }
                    }


                    i++;
                    if (tarro >= abejas.Length)
                        i = 0;
            }

            terminado++;
        }

        void Oso()
        {
            while(numVecesOsoEchoLaPapa < 3)
            {
                if (osoPuedeComer == true)
                {
                    tarro = 0;
 
                    Console.WriteLine("El winnepooh ta echando la papa");
                    osoPuedeComer = false;
                }
                
            }
            terminado++;
        }
    }
}
