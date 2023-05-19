using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analizadorLexico
{
    internal class token
    {
        public enum Tipotoken
        {
            NUMERO_ENTERO,
            NUMERO_FLOTANTE,
            SIMBOLO_GATO,
            SIMBOLO_MAYOR,
            SIMBOLO_MENOR,
            SIMBOLO_MAS,
            SIMBOLO_MENOS,
            SIMBOLO_ASTEDISCO,
            SIMBOLO_DIVISION,
            SIMBOLO_PARENTESIS_ABIERTO,
            SIMBOLO_PARENTESIS_CERRADO,
            SIMBOLO_LLAVE_ABIERTA,
            SIMBOLO_LLAVE_CERRADA,
            SALTO_DE_LINEA,
            SIMBOLO_PUNTO,
            COMILLAS,
            IGUAL,
            PUNTO_COMA,
            PARENTESIS,
            PORCENTAGE,
            PORCENTAGE_C,
            PORCENTAGE_D,
            PORCENTAGE_F,
            COMA,
            PUNTO,
            AMPERSAN,
            PORSENTAGE,
            CORCHETE_CIERRE,
            CORCHETE_ABRE,
            PALABRA_RESERVADA, 
            IDENTIFICADOR,
            LIBRERIA,
            DIAGONAL,
            COMENTARIO,
            DIFERENTE,
            COMENTARIO_ABRE,
            COMENTARIO_CIERRA,
            PORCENTAGE_S,
            PUNTOS,
            TEXTO


        }
        Tipotoken Dtoken;
        string valor;

        public token(Tipotoken ttoken, String v)
        {
            this.Dtoken = ttoken;
            this.valor = v;
        }
        public String GetValueToken()
        {
            return valor;
        }
        public String GetTipoToken()
        {
            switch (Dtoken)
            {
                case Tipotoken.NUMERO_ENTERO:
                    return "Numero Entero";
                case Tipotoken.NUMERO_FLOTANTE:
                    return "Numero Flotante";
                case Tipotoken.SIMBOLO_GATO:
                    return "Simbolo Gato";
                case Tipotoken.SIMBOLO_MAYOR:
                    return "Simbolo Mayor";
                case Tipotoken.SIMBOLO_MENOR:
                    return "Simbolo Menor";
                case Tipotoken.SIMBOLO_PARENTESIS_ABIERTO:
                    return "Simbolo Parentesis Abierto";
                case Tipotoken.SIMBOLO_PARENTESIS_CERRADO:
                    return "Simbolo parentesis Cerrado";
                case Tipotoken.SIMBOLO_LLAVE_ABIERTA:
                    return "Simbolo Llave Abierta";
                case Tipotoken.SIMBOLO_LLAVE_CERRADA:
                    return "Simbolo Llave Cerrada";
                case Tipotoken.SIMBOLO_PUNTO:
                    return "Simbolo Punto";
                case Tipotoken.TEXTO:
                    return "Es un Texto";
                case Tipotoken.COMILLAS:
                    return "Es una Comilla";
                case Tipotoken.IGUAL:
                    return "Es un signo de Igual";
                case Tipotoken.PUNTO_COMA:
                    return "Es Punto y coma";
                case Tipotoken.PARENTESIS:
                    return "Es un parentesis";
                case Tipotoken.PORCENTAGE_C:
                    return "Porcentage c";
                case Tipotoken.PORCENTAGE_D:
                    return "PORCENTAGE D";
                case Tipotoken.PORCENTAGE_F:
                    return "PORCENTAGE F";
                case Tipotoken.PORCENTAGE_S:
                    return "PORCENTAGE s";
                case Tipotoken.COMA:
                    return "Es una coma";
                case Tipotoken.AMPERSAN:
                    return "Es Ampersan";
                case Tipotoken.PORSENTAGE:
                    return "Es un Porcentage";
                case Tipotoken.CORCHETE_ABRE:
                    return "Corchete que abre";
                case Tipotoken.CORCHETE_CIERRE:
                    return "Corchete que cierra";
                case Tipotoken.PALABRA_RESERVADA:
                    return "Es una palabra reservada";
                case Tipotoken.IDENTIFICADOR:
                    return "Es un identificador";
                case Tipotoken.LIBRERIA:
                    return "Es una libreria";
                case Tipotoken.DIAGONAL:
                    return "Es una diagonal";
                case Tipotoken.COMENTARIO:
                    return "Es un Comentario";
                case Tipotoken.SIMBOLO_MAS:
                    return "Simbolo más";
                case Tipotoken.SIMBOLO_MENOS:
                    return "Simbolo menos";
                case Tipotoken.SIMBOLO_DIVISION:
                    return "Simbolo Division";
                case Tipotoken.SIMBOLO_ASTEDISCO:
                    return "Es un astedisco";
                case Tipotoken.SALTO_DE_LINEA:
                    return "Salto de linea";
                case Tipotoken.PORCENTAGE:
                    return "Simbolo de Porcentaje";
                case Tipotoken.DIFERENTE:
                    return "Diferente";
                case Tipotoken.PUNTO:
                    return "Es un punto";
                case Tipotoken.PUNTOS:
                    return "Son 2 puntos";
                default:
                    return "Simbolo Desconocido :(";

            }
        }
    }
}
