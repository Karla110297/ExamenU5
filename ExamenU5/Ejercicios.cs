using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU5
{
    public class Ejercicios
    {
        //**************************************************************MENU******************************************************************//
        public void Menu()
        {
            Console.WriteLine("¿Que numero de ejercicio?");
            Console.WriteLine("1, 2, 3 o 4 y  otro para salir");//0 para que se realize la accion default que es salirse
            int numero = int.Parse(Console.ReadLine());

            switch (numero)
            {
                case 1:
                    Console.Clear();
                    Ejercicio1();

                    Console.ReadKey();
                    Menu();//Regresa al menu
                    break;
                case 2:
                    Console.Clear();
                    Ejercicio2();

                    Console.ReadKey();
                    Menu();
                    break;
                case 3:
                    Console.Clear();
                    Ejercicio3();

                    Console.ReadKey();
                    Menu();
                    break;
                case 4:
                    Console.Clear();
                    Ejercicio4();

                    Console.ReadKey();
                    Menu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Adios");
                    break;

            }
        }

        //****************************************************EJERCICIOS***********************************************
        private void Ejercicio1()
        {
            /* Problema 1.- Construya una aplicación que genere un ordenamiento de n números 
             * y que solo se puedan introducir 0,1, 2 de cualquier forma, use el método bubble
             * sort para hacer este problema, Nota: valide la inserción de números.*/

            Console.WriteLine("¿Cuantos elementos desea agregar en su arreglo?");
            int n = int.Parse(Console.ReadLine());//este sera el tamaño del arreglo

            int[] arreglo = new int[n];

            for (int i = 0; i < n; i++)
            {

                do//mientras no este en el rango se va a preguntar por el mismo numero
                {

                    try
                    {
                        Console.WriteLine("Inserte numero {0}, Especificación: Inserte un numero entre 0 y 2", i + 1);
                        arreglo[i] = int.Parse(Console.ReadLine());

                        if (arreglo[i] >= 3 || arreglo[i] < 0)//si no esta en el rango lanza excepcion
                        {
                            throw new Exception();
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("El numero debe ser desde 0 a 2", e);//mensaje a usuario para que corrija
                    }


                } while (arreglo[i] >= 3 || arreglo[i] < 0);

            }

            Imprimir(arreglo, 1);


            Console.WriteLine();
            Console.ReadKey();

        }

        private void Ejercicio2()
        {
            /*Problema 2.- Genere un método int que obtenga el valor de 80 números random positivos,
             * y ordenelos con el método radix, en cada ejecución del programa los números no deben 
             * ser iguales(ya que son random).*/
            Random r = new Random();
            int[] arreglo = new int[80];

            for (int i = 0; i < arreglo.Length; i++)
            {
                int numeroRandom = r.Next(0, Int32.MaxValue);

                while (arreglo.Contains(numeroRandom)) //Si el elemento ya esta en arreglo se repite el ciclo hasta agragar un elemento random diferente al arreglo
                {

                    numeroRandom = r.Next();

                }

                arreglo[i] = numeroRandom;

            }

            Imprimir(arreglo, 2);
            Console.WriteLine();
            Console.ReadKey();

        }

        private void Ejercicio3()
        {
            /*Problema 3.- Con el método shellsort haga un algoritmo que le pida al usuario 
            n cantidad de numeros y permita ordenarlos de mayor a menor.*/


            Console.WriteLine("¿Cuantos elementos desea agregar en su arreglo?");
            int n = int.Parse(Console.ReadLine());//este sera el tamaño del arreglo

            int[] arreglo = new int[n];

            for (int i = 0; i < n; i++)//llena arreglo
            {

                Console.WriteLine("Inserte numero {0}", i + 1);
                arreglo[i] = int.Parse(Console.ReadLine());

            }

            Imprimir(arreglo, 3);//imprime el arreglo de forma desordenada y ordenada


            Console.WriteLine();
            Console.ReadKey();
        }

        private void Ejercicio4()
        {
            /*Problema 4.- En base a la jerarquía de el abecedario ordene la siguiente frase: 
             * " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce varius, augue 
             * vitae tincidunt viverra, sem felis bibendum nisl, id cursus diam leo sit amet urna. 
             * Duis ac massa est." 
             * Nota: Comprendiendo que la primera letra del abecedario es 1, A=1, B=2, C=3.. etc .
             * Use el metodo Quicksort*/

            string frase = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce varius, augue" +
             "vitae tincidunt viverra, sem felis bibendum nisl, id cursus diam leo sit amet urna" +
             " Duis ac massa est";//frase a ordenar

            Console.WriteLine("Frase sin modificaciones: \n" + frase + "\n");//Imprime frase sin cambios

            frase = frase.ToLower();//pone toda la frase en minusculas
            frase = frase.Replace(".", "").Replace(",", "").Replace(" ", "");//elimina los signos de puntuacion y espacios
            char[] letrasSeparadas = frase.ToCharArray();//convierte la frase en un arreglo char
            char[] letras = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };//letras de abecedario ordenadas

            int[] numeros = new int[letrasSeparadas.Length];//crea un arreglo de numeros del tamaño e arreglo char


            for (int i = 0; i < letrasSeparadas.Length; i++)//llena el arreglo de numeros conforme a la posicion del abecedario en el arreglo char
            {
                numeros[i] = BuscarIndice(letras, letrasSeparadas[i]) + 1;//busca el indice de cada letra y agrega 1 para que se inicialice en 1 en igual de 0
            }

            Console.WriteLine("Frase sin signos de puntuacion y sin ordenar: \n {0} \n ", frase);//impreme frase sin ordenar pero ya modificada

            Imprimir(numeros, 4);//imprime el arreglo de numeros sin ordenar y luego ordenado
            Console.WriteLine();

            Console.WriteLine("Frase sin signos de puntuacion y ordenada: \n ");//impreme frase ordenada
            for (int i = 0; i < numeros.Length; i++)//imprime letras ordenadamente utilizando el arreglo de numeros ordenado -1 como indice
            {
                Console.Write(letras[numeros[i] - 1] + ", ");
            }


            Console.WriteLine();
            Console.ReadKey();


        }

        
        ///*************************************************METODOS EN EJERCICIOS****************************************************
        private void Imprimir(int[] arreglo, int ejercicio)// imprime el arreglo ordenado
        {
            Console.WriteLine("Numeros sin ordenar");
            for (int i = 0; i < arreglo.Length; i++)//imprime arreglo sin ordenar
            {
                Console.Write(arreglo[i] + ", ");
            }

            switch (ejercicio)//conforme cual sea el ejercicio es el metodo de ordenamiento que se va a llamar
            {

                case 1:
                    bubblesort(arreglo);//manda llamar funcion bubblesort para ordenar

                    break;

                case 2:
                    radixSort(arreglo);//manda llamar radix 

                    break;
                case 3:
                    Shellsort(arreglo);

                    Console.WriteLine("\n\nNumeros ordenados de mayor a menor ");//imprime arreglo ordenado de mayor a menor
                    for (int j = arreglo.Length-1; j >=0; j--)
                    {
                        Console.Write("{0}, ", arreglo[j]);
                    }

                    goto FIN;// termina la funcion aqui porque ya se imprimio el orden
                    
            
                case 4:
                    quicksort(arreglo, 0, arreglo.Length - 1);//manda llamar quicksort como metodo de ordenamiento

                    break;
                default:
                    break;

            }

            Console.WriteLine("\n\nNumeros ordenados");//imprime arreglo ordenado
            for (int j = 0; j < arreglo.Length; j++)
            {
                Console.Write("{0}, ", arreglo[j]);
            }

            FIN:;
        }

        private int BuscarIndice(char[] arreglo, char buscarLetra)//se pide arreglo y letra que se va a buscar
        {
            arreglo[arreglo.Length - 1] = buscarLetra;

            int i;
            for (i = 0; arreglo[i] != buscarLetra; i++) ;
            return (i < arreglo.Length - 1) ? i : -1;// se regresa el numero que corresponde al indice del elemento que se busco
        }




        //**********************************METODOS DE ORDENAMIENTO*******************************************************************************


        private void bubblesort(int[] arreglo)
        {
            bool estaOrdenado = false;
            int ultimoDesordenado = arreglo.Length - 1;// para disminuir el rango

            while (!estaOrdenado)//mientras el arreglo este desordenado
            {
                estaOrdenado = true;//asume que esata ordenado

                for (int i = 0; i < ultimoDesordenado; i++)
                {
                    if (arreglo[i] > arreglo[i + 1])//si el elemento anterior es mayor al siguiente
                    {

                        int temp = arreglo[i];//utilizo una auxiliar para mantener un valor temporalmente
                        arreglo[i] = arreglo[i + 1];
                        arreglo[i + 1] = temp;
                        estaOrdenado = false;// si algo esta desordenado lo vueleve a poner en falso
                    }
                }

                ultimoDesordenado--;
            }

        }

        private void quicksort(int[] arreglo, int primero, int ultimo)//ordena el arreglo y para eso pide el arreglo, el primer indice y el ultimo
        {
            int i = primero, j = ultimo;

            int indice = (primero + ultimo) / 2;//se realiza un indice para utilizar como pivote

            int pivote = arreglo[indice];
            int auxiliar;//variable temporal
            do
            {
                while (arreglo[i] < pivote) { i++; }//recorre arreglo
                while (arreglo[j] > pivote) { j--; }//recorre arreglo

                if (i <= j)//cambia posiciones
                {
                    auxiliar = arreglo[j];
                    arreglo[j] = arreglo[i];
                    arreglo[i] = auxiliar;
                    i++;
                    j--;
                }

            } while (i <= j);

            if (primero < j) { quicksort(arreglo, primero, j); }
            if (ultimo > i) { quicksort(arreglo, i, ultimo); }

        }





        private void radixSort(int[] arreglo)
        {
            int[] t = new int[arreglo.Length]; // Arreglo auxiliar .

            int r = 2;// Tamaño en bits de nuestro grupo. 

            int b = 32; // Número de bits de un entero en c#. 



            int[] count = new int[1 << r];            // Inicia el conteo a asignación de los arreglos.
            int[] pref = new int[1 << r]; // Notar dimensiones 2^r el cual es el número de todos los  valores posibles de un número r-bit


            int groups = (int)Math.Ceiling((double)b / (double)r);// Número de grupos.



            int mask = (1 << r) - 1;// Máscara para identificar los grupos.


            for (int c = 0, shift = 0; c < groups; c++, shift += r)// Implementación del algoritmo 
            {

                for (int j = 0; j < count.Length; j++)// Reiniciar el conteo en los arreglos.
                    count[j] = 0;

                for (int i = 0; i < arreglo.Length; i++)                // Contar elementos del c-vo grupo.
                    count[(arreglo[i] >> shift) & mask]++;


                pref[0] = 0; // Calculando prefijos.

                for (int i = 1; i < count.Length; i++)
                    pref[i] = pref[i - 1] + count[i - 1];



                for (int i = 0; i < arreglo.Length; i++) // De a[] a t[] elementos ordenados por c-vo grupo .
                    t[pref[(arreglo[i] >> shift) & mask]++] = arreglo[i];



                t.CopyTo(arreglo, 0);// a[]=t[] e inicia otra vez hasta el último grupo. 


            }

            // Está ordenado 	   
        }


        private void Shellsort(int[] arreglo)
        {
            int salto = 0;
            int c = 0;//constante que va a ir cambiando conforme se vaya recorriendo el arreglo
            int auxiliar = 0;//auxiliar de ayuda para intercambiar posiciones
            int l = 0;//elemento que ayuda a limitar el rango
            salto = arreglo.Length / 2;//tamaño de distancia que abra entre numeros siendo comparados
            while (salto > 0)
            {
                c = 1;
                while (c != 0)//recorre todo el arreglo para hacer comparaciones
                {
                    c = 0;
                    l = 1;
                    while (l <= (arreglo.Length - salto))
                    {
                        if (arreglo[l - 1] > arreglo[(l - 1) + salto])//se compara posiciones conforme al salto y se realiza el cambio de posicion
                        {
                            auxiliar = arreglo[(l - 1) + salto];
                            arreglo[(l - 1) + salto] = arreglo[l - 1];
                            arreglo[(l - 1)] = auxiliar;
                            c = 1;
                        }
                        l++;
                    }
                }
                salto = salto / 2;
            }
        }


    }
}
