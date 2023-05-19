using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analizadorLexico
{
    internal class analizadorLexico
    {
        LinkedList<token> Salida;
        int estado;
        String auxToken;
        private int cont1 = 0;
        

        public LinkedList<token> Escanear(string entrada)
        {
            Salida = new LinkedList<token>();
            estado = 0;
            auxToken = "";
            char c;
            for (int i = 0; i < entrada.Length; i++)
            {
                c = entrada.ElementAt(i);
                int contador = 0, paso = 0;
                
                switch (estado)
                {
                    case 0:
                        if (char.IsDigit(c))
                        {
                            estado = 4;
                            auxToken += c;
                        }
                        else if (c.CompareTo('[') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.CORCHETE_ABRE);
                        }
                        else if (c.CompareTo(']') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.CORCHETE_CIERRE);
                        }
                        else if (c.CompareTo('<') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.SIMBOLO_MENOR);
                        }
                        else if (c.CompareTo('>') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.SIMBOLO_MAYOR);
                        }
                        else if (c.CompareTo('#') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.SIMBOLO_GATO);
                        }
                        else if (c.CompareTo('{') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.SIMBOLO_LLAVE_ABIERTA);
                        }
                        else if (c.CompareTo('}') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.SIMBOLO_LLAVE_CERRADA);
                        }
                        else if (c.CompareTo('(') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.SIMBOLO_PARENTESIS_ABIERTO);
                        }
                        else if (c.CompareTo(')') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.SIMBOLO_PARENTESIS_CERRADO);
                        }
                        else if (c.CompareTo(':') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.PUNTOS);
                        }
                        else if (c.CompareTo('"') == 0)
                        {

                            auxToken += c;
                            agregarToken(token.Tipotoken.COMILLAS);
                            contador++;
                            if (contador % 2 != 0)
                            {
                                paso++;
                                estado = 10;
                            }
                        }
                        else if (c.CompareTo('=') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.IGUAL);

                        }
                        else if (c.CompareTo(';') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.PUNTO_COMA);

                        }
                        else if (c.CompareTo('%') == 0)
                        {
                            auxToken += c;
                            estado = 15;

                        }
                        else if (c.CompareTo(',') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.COMA);

                        }
                        else if (c.CompareTo('/') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.DIAGONAL);
                            if (c.CompareTo('/') == 0)
                            {
                                cont1++;
                                
                                estado = 11;
                            }   

                        }
                        else if (c.CompareTo('&') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.AMPERSAN);

                        }
                        else if (c.CompareTo('+') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.SIMBOLO_MAS);

                        }
                        else if (c.CompareTo('-') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.SIMBOLO_MENOS);

                        }
                        else if (c.CompareTo('*') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.SIMBOLO_ASTEDISCO);

                        }
                        else if (c.CompareTo('!') == 0)
                        {
                            auxToken += c;
                            estado = 18;

                        }
                        else if (c.CompareTo('\\') == 0)
                        {
                            auxToken += c;
                            estado = 19;

                        }
                        else if (c.CompareTo('.') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.PUNTO);

                        }
                        else if (char.IsLetter(c))
                        {
                            auxToken += c;
                            estado = 1;
                        }

                        break;
                    case 1:

                        if (char.IsLetter(c))
                        {

                            estado = 1;
                            auxToken += c;

                        }
                        else if (char.IsDigit(c))
                        {
                            estado = 2;
                            auxToken += c;

                        }
                        else if (c.CompareTo('_') == 0)
                        {
                            estado = 3;
                            auxToken += c;

                        }
                        else if (c.CompareTo('.') == 0)
                        {
                            
                            estado = 8;
                            auxToken += c;
                        }
                        else
                        {

                            int a = Busca_palabra_reservada(auxToken);
                            if (a == 0) agregarToken(token.Tipotoken.IDENTIFICADOR);
                            else agregarToken(token.Tipotoken.PALABRA_RESERVADA);

                            i -= 1;

                        }
                        break;

                    case 2:
                        if (char.IsDigit(c))
                        {
                            estado = 2;
                            auxToken += c;
                        }
                        else
                        {
                            agregarToken(token.Tipotoken.NUMERO_ENTERO);
                            i -= 1;
                        }

                        break;
                    case 3:
                        if (char.IsLetter(c))
                        {
                            estado = 7;
                            auxToken += c;
                        }
                        else if (char.IsDigit(c))
                        {
                            estado = 1;
                            auxToken += c;

                        }
                        else
                        {
                            agregarToken(token.Tipotoken.IDENTIFICADOR);
                            i -= 1;
                        }
                        break;
                    case 4:
                        if (char.IsDigit(c))
                        {
                            estado = 4;
                            auxToken += c;

                        }
                        else if (c.CompareTo('.') == 0)
                        {
                            estado = 5;
                            auxToken += c;

                        }
                        else
                        {
                            agregarToken(token.Tipotoken.NUMERO_ENTERO);
                            i -= 1;
                        }
                        break;
                    case 5:
                        if (char.IsDigit(c))
                        {
                            estado = 6;
                            auxToken += c;

                        }
                        else
                        {
                            agregarToken(token.Tipotoken.NUMERO_FLOTANTE);
                            i -= 1;
                        }
                        break;
                    case 6:
                        if (char.IsDigit(c))
                        {
                            estado = 6;
                            auxToken += c;

                        }
                        else
                        {
                            agregarToken(token.Tipotoken.NUMERO_FLOTANTE);
                            i -= 1;
                        }
                        break;

                    case 7:
                        if (char.IsLetter(c))
                        {
                            estado = 7;
                            auxToken += c;
                        }
                        else
                        {
                            agregarToken(token.Tipotoken.IDENTIFICADOR);
                            i -= 1;
                        }
                        break;
                    case 8:
                        if (c.CompareTo('h') == 0)
                        {

                            estado = 9;
                            auxToken += c;
                        }                     
                        break;
                    case 9:
                        agregarToken(token.Tipotoken.LIBRERIA);
                        i -= 1;

                        break;
                    case 10:

                        if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                        {
                            paso++;
                            estado = 10;
                            auxToken += c;
                        }
                        else if (c.CompareTo('"') == 0)
                        {
                            if (auxToken.Length > 0)
                            {
                                agregarToken(token.Tipotoken.TEXTO);
                                i -= 1;
                            }
                            else
                            {
                                estado = 0;
                                i -= 1;
                            }
                            
                        }
                        else
                        {
                            estado = 0;
                            i -= 1;
                        }
                        
                        break;
                    case 11:
                        if (c.CompareTo('/') == 0) 
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.DIAGONAL);
                            estado = 11;
                            
                        }
                        else if (char.IsLetter(c))
                        {
                            estado = 12;
                            auxToken += c;
                        }
                        else if (c.CompareTo('*')==0)
                        {
                            cont1++;
                            auxToken += c;
                            agregarToken(token.Tipotoken.SIMBOLO_ASTEDISCO);
                            estado = 13;
                        }
                        break;
                    case 12:
                        if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == ':' || c == '(' || c == ')')
                        {

                            estado = 12;
                            auxToken += c;
                        }
                        else
                        {
                            agregarToken(token.Tipotoken.COMENTARIO);
                            i -= 1;
                        }
                        break;
                    case 13:
                        if (char.IsLetter(c))
                        {
                            estado = 14;
                            auxToken += c;
                        }
                        break;
                    case 14:
                        if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == ':' || c == '(' || c == ')')
                        {

                            estado = 14;
                            auxToken += c;
                        }
                        else if (c.CompareTo('*') == 0)
                        {
                            cont1++;
                            agregarToken(token.Tipotoken.COMENTARIO);
                            i -= 1;
                            estado = 42;
                        }
                        break;
                    case 15:
                        if (c.CompareTo('d') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.PORCENTAGE_D);
                            
                            
                        }
                        else if (c.CompareTo('f') == 0)
                        {
                            auxToken += c;
                            estado = 16;

                        }
                        else if (c.CompareTo('c') == 0)
                        {
                            auxToken += c;
                            estado = 17;

                        }
                        else if (c.CompareTo('s') == 0)
                        {
                            auxToken += c;
                            estado = 41;

                        }

                        break;
                    case 16:
                        auxToken += c;
                        agregarToken(token.Tipotoken.PORCENTAGE_F);
                        
                        break;
                    case 17:
                        auxToken += c;
                        agregarToken(token.Tipotoken.PORCENTAGE_C);
                        break;
                    case 18:
                        if (c.CompareTo('=') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.DIFERENTE);

                        }
                        break;
                    case 19:
                        if (c.CompareTo('n') == 0)
                        {
                            auxToken += c;
                            agregarToken(token.Tipotoken.SALTO_DE_LINEA);

                        }
                        break;
                    case 41:
                        auxToken += c;
                        agregarToken(token.Tipotoken.PORCENTAGE_S);
                        break;
                    case 42:
                        if (c.CompareTo('*') == 0)
                        {
                            cont1++;
                            auxToken += c;
                            agregarToken(token.Tipotoken.SIMBOLO_ASTEDISCO);
                            estado = 42;
                            
                        }else if (c.CompareTo('/') == 0)
                        {
                            cont1++;
                            auxToken += c;
                            agregarToken(token.Tipotoken.DIAGONAL);

                        }
                        else
                        {

                            i -= 1;
                        }

                        break;
                }

            }
            return Salida;
        }
        public void agregarToken(token.Tipotoken tipo)
        {
            Salida.AddLast(new token(tipo, auxToken));
            auxToken = "";
            estado = 0;
        }
        public String ImprimirListaToken(LinkedList<token> lista)
        {
            String ListaToken = "";
            foreach (token item in lista)
            {
                ListaToken = ListaToken + Convert.ToString(item.GetTipoToken() + " " + item.GetValueToken() + "\n");
            }

            return ListaToken;
        }
        public int Busca_palabra_reservada(String cadena)
        {
            int band = 0;
            string[] palabras_reservadas = { "include", "strcpy","define", "int", "float", "char", "main", "printf", "break", "case", "conts", "dafaul", "do", "double", "else", "if", "enum", "extern", "for", "while", "long", "return", "short", "signed", "sizeof", "static", "struct", "switch", "typedef", "union", "unsigned", "void", "volatileS", "puts", "putchar" };

            foreach (string s in palabras_reservadas)
            {
                if (s.Equals(cadena))
                {
                    band = 1;
                    break;
                }
            }
            return band;
        }

        internal int cont(int y)
        {
            return cont1;
            throw new NotImplementedException();
        }
        
    }
}
