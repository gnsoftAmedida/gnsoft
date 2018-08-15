﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Utilidades;
using System.Globalization;
using Microsoft.VisualBasic;
using System.IO;

namespace Negocio
{
    public sealed class Controladora
    {
        private static readonly Controladora instance = new Controladora();

        private Controladora() { }

        public static Controladora Instance
        {
            get
            {
                return instance;
            }
        }

        public bool controlarLicencia()
        {
            if (FuncionesSeguridad.GetMacAddress().ToString() == VariablesGlobales.Licencia.ToString())
            {
                return true;
            };
            return false;
        }

        public string Padeo(String cadena, int largo)
        {
            string cadena2;
            cadena2 = "0";
            for (int i = 1; i <= largo - 1; i++)
            {
                cadena2 = cadena2 + "0";
            }
            
            cadena2 = Microsoft.VisualBasic.Strings.Mid(cadena2, 1, largo - Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(cadena))) + cadena;
            return cadena2;
        }

        public string PadeoBlancos(String cadena, int largo)
        {
            string cadena2;

            if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(cadena)) > largo)
            {

                cadena = Microsoft.VisualBasic.Strings.Mid(cadena, 1, largo);
            }
            cadena2 = " ";
            for (int i = 1; i <= largo - 1; i++)
            {
                cadena2 = cadena2 + " ";
            }
            cadena2 = Microsoft.VisualBasic.Strings.Mid(cadena2, 1, largo - Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(cadena))) + cadena;
            return cadena2;
        }

        public string generarInterfaces(String CboIncisos, String CboOficinas, String TxtMes, String TxtAño, String unidad)
        {
            double Total = 0;
            int CantidadGente = 0;
            String Primero = "";
            String NombreArchivo;
            String Presupuesto; // Presupuesto As String * 7
            String Oficina = "";
            String WInciso = "";
            String Segundo = "0";
            String Tercero;
            String Control;
            String Busqueda;
            String Mensaje = "";
            Double Parcial = 0;

            Presupuesto = TxtMes + "/" + TxtAño;
            NombreArchivo = "NoHayCodigos";
            Parcial = 0;

            /* 
   
            
              Nombre As String
              MesAño As String
           
              
             'Unidad = CboUnidad.Text
                      */

            /*  '****************************************************************************
              'Comentado porque ahora va el nuevo formato que va despues de este comentario
              '****************************************************************************
   
              'If Mid(CboIncisos, 1, 2) = "05" And Mid(CboOficinas, 1, 2) = "01" Then
              '   Primero = "S0205010001630" 'Secretaría del Ministerio de Economía y Finanzas
              '   NombreArchivo = "MEF" & TxtMes & Mid(TxtAño, 3) & ".TXT"
              '   Oficina = "01"
              '   WInciso = "05"
             */

            if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "05" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "01")
            {
                Primero = "S0205010001000630"; //Secretaría del Ministerio de Economía y Finanzas
                NombreArchivo = "MEF" + TxtMes + Microsoft.VisualBasic.Strings.Mid(TxtAño, 3) + ".TXT";
                Oficina = "01";
                WInciso = "05";

            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "05" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "02")
            {
                Primero = "S0205020002630"; //contaduría General
                NombreArchivo = "CONT" + TxtMes + Microsoft.VisualBasic.Strings.Mid(TxtAño, 3) + ".TXT";
                Oficina = "02";
                WInciso = "05";

            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "05" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "14")
            {
                Primero = "S0205140014630"; //Comercio Exterior
                NombreArchivo = "COEX" + TxtMes + Microsoft.VisualBasic.Strings.Mid(TxtAño, 3) + ".TXT";
                Oficina = "14";
                WInciso = "05";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "11" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "21")
            {
                Primero = "S0211110021630"; // Registro Civil
                NombreArchivo = "COOPMEF" + TxtMes + Microsoft.VisualBasic.Strings.Mid(TxtAño, 3) + ".TXT";
                Oficina = "21";
                WInciso = "11";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "05" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "05")
            {
                Primero = "D02"; //Impositiva
                Segundo = "000907";
                NombreArchivo = "DETALLE.TXT";
                Oficina = "05";
                WInciso = "05";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "05" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "07")
            {
                NombreArchivo = "ADUANA.TXT"; // Aduanas
                Oficina = "07";
                WInciso = "05";

            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "07" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "01")
            {
                Primero = "S0207000000000645"; //Secretaría del Ministerio Ganadería Agricultura y pesca
                NombreArchivo = "MGAP" + TxtMes + Microsoft.VisualBasic.Strings.Mid(TxtAño, 3) + ".TXT";
                Oficina = "01";
                WInciso = "07";

            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "99")  //Jubilados
            {
                Primero = Microsoft.VisualBasic.Strings.Mid(Presupuesto, 4) + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 1, 2);
                Segundo = "0006685";
                Tercero = "DO00001001210";
                NombreArchivo = "Dto685" + Primero + ".dat";
                WInciso = "05";
                Oficina = "99";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "13")  //Ministerio de Trabajo"             
            {
                NombreArchivo = Microsoft.VisualBasic.Strings.Mid(Presupuesto, 6, 2) + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 1, 2) + "568.MTS";
                WInciso = "13";
                Oficina = "01";
                ; //} else if ( Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "123" ) ; //Salud Publica"
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "29")  //ASSE MODIFICADO
            {
                NombreArchivo = "MSP" + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 1, 2) + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 6, 2) + ".TXT";
                Primero = "00083047";
                Segundo = Microsoft.VisualBasic.Strings.Mid(Presupuesto, 1, 2);
                Tercero = Microsoft.VisualBasic.Strings.Mid(Presupuesto, 4);
                WInciso = "29";
                Oficina = "01";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "10")  // Ministerio de Transporte y Obras Publicas
            {
                NombreArchivo = "CACMEF389.TXT";
                Segundo = "0389";
                Tercero = "CACMEF";
                WInciso = "10";
                Oficina = "01";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "97" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "97")  // Empleados DGSS
            {
                NombreArchivo = "C" + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 1, 2) + "0887.txt";
                WInciso = "97";
                Oficina = "97";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "05" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "08")  //Loterias
            {
                NombreArchivo = "Loterias.txt";
                Primero = "S0200005008595";
                WInciso = "05";
                Oficina = "08";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "96" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "04")  // Secundaria
            {
                NombreArchivo = "739_d3";
                WInciso = "96";
                Oficina = "04";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "96" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "03")  // UTU este habría que sacarlo cu&&o quede el formato CSV
            {
                NombreArchivo = "C76" + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 6) + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 1, 2) + ".TXT";
                WInciso = "96";
                Oficina = "03";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "96" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "10")  //UTU FORMATO CSV
            //Modificado 29/10/2010 según instrucciones de UTU
            {

                NombreArchivo = "Cacfsmef_276.csv";
                Primero = "Formato1,Cedula,Funcionario,Codigo,Importe,Nombre,CedulaBeneficiario,NombreBeneficiario";
                WInciso = "96";
                Oficina = "10";

            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "96" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "02")  // CODICEN
            {
                ; //Modificado 19/05/2010 según instrucciones del codicen
                ; //NombreArchivo = "Codicen.csv" Cambio en nombre de archivo
                NombreArchivo = "Cacfsmef_739.csv";
                Primero = "Formato1,Cedula,Funcionario,Codigo,Importe,Nombre,CedulaBeneficiario,NombreBeneficiario";
                WInciso = "96";
                Oficina = "02";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "96" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "01")  // CONSEJO EDUC. PRIMARIA
            {
                NombreArchivo = "CEP.txt";
                ; //Primero = "Formato1,Cedula,Funcionario,Codigo,Importe,Nombre,CedulaBeneficiario,NombreBeneficiario"
                WInciso = "96";
                Oficina = "01";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "20" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "02")  // INTENDENCIA DE CANELONES
            {
                NombreArchivo = "IMC" + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 1, 2) + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 4) + ".TXT";
                ; //Primero = "Formato1,Cedula,Funcionario,Codigo,Importe,Nombre,CedulaBeneficiario,NombreBeneficiario"
                WInciso = "20";
                Oficina = "02";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "26" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "09")  // FACULTAD DE ODONTOLOGIA
            {
                NombreArchivo = "DTO" + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 1, 2) + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 6) + ".368";
                WInciso = "26";
                Oficina = "09";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "26" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "15")  // HOSPITAL DE CLINICAS
            {
                NombreArchivo = "DTO" + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 1, 2) + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 6) + ".368";
                WInciso = "26";
                Oficina = "15";

            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "30" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "01")  // ANTEL
            {
                NombreArchivo = "ANTEL" + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 1, 2) + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 4) + ".TXT";
                WInciso = "30";
                Oficina = "01";
            }
            else if (Microsoft.VisualBasic.Strings.Mid(CboIncisos, 1, 2) == "04" && Microsoft.VisualBasic.Strings.Mid(CboOficinas, 1, 2) == "06")
            {
                Primero = "S0204006000000375"; //Jefatura de Policia de Canelones
                NombreArchivo = "CooperativaMEF" + TxtMes + Microsoft.VisualBasic.Strings.Mid(TxtAño, 3) + ".TXT";
                Oficina = "06";
                WInciso = "04";
            }
            Control = WInciso + Oficina;

            if (Oficina != "99")
            {
                //este if lo puse para agregar la oficina 10 que corresponde a UTU el segundo formato que hay que mandar CSV luego cuando quede solo
                //este último formato sacarlo y corregir el código 29/10/2010

                if (Control == "9610")
                {
                    //Corregido
                    Busqueda = "SELECT DISTINCTROW historia.presupuesto,historia.numeroprestamo, " +
                        "historia.cedula,historia.importecuota,historia.aportecapital,historia.numerocobro, " +
                        "historia.inciso, historia.oficina,historia.excedido, historia.mora,historia.ivamora,socio.socio_nombre, " +
                        "socio.socio_apellido, socio.socio_departamento, socio.socio_fechaIngreso,socio.socio_detalles " +
                        "FROM socio INNER JOIN historia on socio.socio_nro=historia.cedula " +
                        "WHERE historia.presupuesto=" + "'" + Presupuesto + "'" + "AND historia.inciso = " + "'" + WInciso + "'" +
                        "AND historia.oficina= '03'" +
                        "ORDER BY historia.cedula;";
                }
                else
                {
                    //Corregido
                    Busqueda = "SELECT DISTINCTROW historia.presupuesto,historia.numeroprestamo, " +
                        "historia.cedula,historia.importecuota,historia.aportecapital,historia.numerocobro, " +
                        "historia.inciso, historia.oficina,historia.excedido, historia.mora,historia.ivamora,socio.socio_nombre, " +
                        "socio.socio_apellido, socio.socio_departamento, socio.socio_fechaIngreso,socio.socio_detalles " +
                        "FROM socio INNER JOIN historia on socio.socio_nro=historia.cedula " +
                        "WHERE historia.presupuesto=" + "'" + Presupuesto + "'" + "AND historia.inciso = " + "'" + WInciso + "'" +
                        "AND historia.oficina=" + "'" + Oficina + "'" +
                        "ORDER BY historia.cedula;";
                }
            }
            else
            {
                //Corregido
                Busqueda = "SELECT DISTINCTROW historia.presupuesto,historia.numeroprestamo, " +
                      "historia.cedula,historia.importecuota,historia.aportecapital,historia.numerocobro, " +
                      "historia.inciso, historia.oficina,historia.excedido, historia.mora,historia.ivamora,socio.socio_nombre, " +
                      "socio.socio_apellido, socio.socio_departamento, socio.socio_fechaIngreso,socio.socio_detalles " +
                      "FROM socio INNER JOIN historia on socio.socio_nro=historia.cedula " +
                      "WHERE historia.presupuesto=" + "'" + Presupuesto + "'" +
                      "AND historia.oficina=" + "'" + Oficina + "'" +
                      "ORDER BY historia.cedula;";
            }

            if (Control == "1001")
            {
                Busqueda = "SELECT DISTINCTROW historia.presupuesto,historia.numeroprestamo, " +
                      "historia.cedula,historia.importecuota,historia.aportecapital,historia.numerocobro, " +
                      "historia.inciso, historia.oficina,historia.excedido, historia.mora,historia.ivamora,socio.socio_nombre, " +
                      "socio.socio_apellido, socio.socio_departamento, socio.socio_fechaIngreso,socio.socio_detalles " +
                      "FROM socio INNER JOIN historia on socio.socio_nro=historia.cedula " +
                      "WHERE historia.presupuesto=" + "'" + Presupuesto + "'" +
                      "AND historia.inciso = " + "'" + WInciso + "'" +
                      "ORDER BY historia.cedula;";
            }


            DataSet resultado = this.devolverBusquedaInterfaz(Busqueda);

            if (resultado.Tables["interfaz"].Rows.Count == 0)
            {
                string mensaje = "No hay datos a procesar";
                return mensaje;
            }


            //NOMBRE DE ARCHIVO Y APERTURA SACARLOS LUEGO.
            if (Microsoft.VisualBasic.Strings.Right(unidad + "Nuevo.txt", 1) != @"\")
            {
                unidad = unidad + @"\";
            }

            StreamWriter sw = new StreamWriter(unidad + "Nuevo.txt", true);

            // este if luego ponerlo en el lugar que esta ahora impositiva. NUEVA MODALIDAD A  PARTIR DE MARZO DE 2007
            if (Control == "0505") //DGI
            {

                for (int n = 0; n <= resultado.Tables["interfaz"].Rows.Count - 1; n++)
                {
                    //Corregido
                    Double importeCuota = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][3].ToString());
                    Double aportecapital = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][4].ToString());
                    string numeroCobro = resultado.Tables["interfaz"].Rows[n][5].ToString();
                    Double Excedido = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][8].ToString());
                    Double Mora = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][9].ToString());
                    Double IvaMora = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][10].ToString());                    
                    Double resultadoInter = importeCuota + aportecapital + Excedido + Mora + IvaMora;
                    String r = this.Padeo(numeroCobro, 6) + "5154" + this.Padeo(resultadoInter.ToString("###,##0"), 8) + "00";

                    sw.WriteLine(r);
                }
            }


            sw = new StreamWriter(unidad + NombreArchivo, true);

            //Open "a:\" & NombreArchivo For Output As #Canal
            //secretaria
            if (Control == "0501")
            {
                for (int n = 0; n <= resultado.Tables["interfaz"].Rows.Count - 1; n++)
                {
                    //Corregido
                    string cedula = resultado.Tables["interfaz"].Rows[n][2].ToString();
                    Double importeCuota = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][3].ToString());
                    Double aportecapital = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][4].ToString());
                    string numeroCobro = resultado.Tables["interfaz"].Rows[n][5].ToString();
                    Double Excedido = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][8].ToString());
                    Double Mora = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][9].ToString());
                    Double IvaMora = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][10].ToString());
                    
                    Double resultadoInter = importeCuota + aportecapital + Excedido + Mora + IvaMora;
                    String r = Primero + this.Padeo(Microsoft.VisualBasic.Strings.Mid(cedula, 1, 7), 15) + this.Padeo(resultadoInter.ToString("###,##0"), 6) + "000000";

                    sw.WriteLine(r);
                }


                //contaduria,Direccion General de Comercio, Registro Civil
            }
            else if (Control == "0502" || Control == "0514" || Control == "1121")
            {
                for (int n = 0; n <= resultado.Tables["interfaz"].Rows.Count - 1; n++)
                {
                    //Corregido
                    string cedula = resultado.Tables["interfaz"].Rows[n][2].ToString();
                    double importeCuota = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][3].ToString());
                    double aportecapital = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][4].ToString());
                    string numeroCobro = resultado.Tables["interfaz"].Rows[n][5].ToString();
                    double Excedido = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][8].ToString());
                    double Mora = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][9].ToString());
                    double IvaMora = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][10].ToString());
                    Double resultadoInter = importeCuota + aportecapital + Excedido + Mora + IvaMora;                    
                    String r = Primero + this.Padeo(numeroCobro, 4) + Padeo(resultadoInter.ToString("###,##0"), 5) + "00";
                    sw.WriteLine(r);                   
                }                
            }

            else if (Control == "0505")
            { //DGI


                for (int n = 0; n <= resultado.Tables["interfaz"].Rows.Count - 1; n++)
                {
                    //Corregido
                    string cedula = resultado.Tables["interfaz"].Rows[n][2].ToString();
                    Double importeCuota = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][3].ToString());
                    Double aportecapital = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][4].ToString());
                    string numeroCobro = resultado.Tables["interfaz"].Rows[n][5].ToString();
                    Double Excedido = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][8].ToString());
                    Double Mora = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][9].ToString());
                    Double IvaMora = Convert.ToDouble(resultado.Tables["interfaz"].Rows[n][10].ToString());
                    Double resultadoInter = importeCuota + aportecapital + Excedido + Mora + IvaMora;

                    String r = Primero + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 1, 2) + Microsoft.VisualBasic.Strings.Mid(Presupuesto, 4) + Segundo + Padeo(numeroCobro, 5) + cedula + Padeo(resultadoInter.ToString("###,##0"), 7) + "00";

                    Total = Total + Convert.ToDouble(resultadoInter);
                    CantidadGente = CantidadGente + 1;

                    sw.WriteLine(r);
                   
                }                
            }

            sw.Flush();
            sw.Dispose();
            return "Interfaces generadas correctamente";
          
            //sacar esta línea para seguir



            /*
                                           ElseIf Control = "0507" Then 'Aduanas
                                               RsHistoria.MoveFirst
                                               While Not RsHistoria.EOF
                                                   Nombre = Trim(RsHistoria!apellidos) & "," & Trim(RsHistoria!Nombres) & Space(60)
                                                   Nombre = Mid(Nombre, 1, 30)
                                                   Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                   Print #Canal, Padeo(RsHistoria!numerocobro, 5) & "0000000000" & Nombre & Padeo((Parcial), 7) & "00" & "0" & Trim(RsHistoria!cedula)
                                                   RsHistoria.MoveNext

                                               Wend
        
                                          ' AGREGADO PARA RETENCIONES DE ENERO DE 2014
                                           'MINISTERIO DE GANADERIA, AGRICULTURA Y PESCA
                                           ElseIf Control = "0701" Then
                                             RsHistoria.MoveFirst
                                             While Not RsHistoria.EOF
                                                Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                Print #Canal, Primero & Padeo(RsHistoria!numerocobro, 15) & Padeo(Parcial, 6) & "000000"
                                                RsHistoria.MoveNext
                                             Wend
      
                                           ElseIf Oficina = "99" Then 'BPS
                                               RsHistoria.MoveFirst
                                               While Not RsHistoria.EOF
                                                   Nombre = Trim(RsHistoria!Nombres) & " " & Trim(RsHistoria!apellidos)
                                                   Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                   Print #Canal, Primero & Segundo & PadeoBlancos(Val(RsHistoria!cedula), 16) & _
                                                   Tercero & Padeo(Parcial, 8) & PadeoBlancos(Nombre, 50) & _
                                                   PadeoBlancos(RsHistoria!numeroprestamo, 10)
                                                   Total = Total + Parcial
                                                   CantidadGente = CantidadGente + 1
                                                   RsHistoria.MoveNext
                                               Wend
                                           ElseIf Control = "1301" Then ' MTSS
                                               RsHistoria.MoveFirst
                                               While Not RsHistoria.EOF
                                                   Nombre = Trim(RsHistoria!apellidos) & " " & Trim(RsHistoria!Nombres)
                                                   Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                   Primero = PadeoBlancos(RsHistoria!numerocobro, 5)
                                                   Segundo = RsHistoria!cedula
                                                   Tercero = "  "
                                                   Print #Canal, Primero & Segundo & Tercero & PadeoBlancos(Nombre, 30) & PadeoBlancos(Parcial, 7) & "00"
                                                   RsHistoria.MoveNext
                                               Wend

                                             'ElseIf Control = "1201" Then ' MSP
                                             ElseIf Control = "2901" Then ' MSP
                                                RsHistoria.MoveFirst
                                                While Not RsHistoria.EOF
                                                   Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                   Print #Canal, Primero & Segundo & Tercero & PadeoBlancos(RsHistoria!numerocobro, 8) & PadeoBlancos(Parcial, 10) & "00" & _
                                                   PadeoBlancos(RsHistoria!numeroprestamo, 8) & Space(12) & Space(5) & "C"
                                                   RsHistoria.MoveNext
                                                Wend
         
                                             ElseIf Control = "1001" Then 'Control = "1001" Then 'MTOP
                                               RsHistoria.MoveFirst
                                               While Not RsHistoria.EOF
                                                   'If RsHistoria!Oficina <> "03" Then
                                                       Primero = RsHistoria!numerocobro
                                                       Nombre = Trim(RsHistoria!apellidos) & "," & Trim(RsHistoria!Nombres) & Space(60)
                                                       Nombre = Mid(Nombre, 1, 30)
                                                       Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                       Print #Canal, Padeo(Primero, 6) & Segundo & Tercero & Nombre & Padeo((Parcial), 7) & "00" & Mid(RsHistoria!cedula, 1, 7) & "-" & Mid(RsHistoria!cedula, 8, 1)
                
                                                   'End If
                                                   RsHistoria.MoveNext
                                               Wend
                                             ElseIf Control = "9797" Then ' Empleados DGSS
                                                RsHistoria.MoveFirst
                                                While Not RsHistoria.EOF
                                                   Primero = RsHistoria!numerocobro
                                                   Segundo = RsHistoria!cedula
                                                   Nombre = Trim(RsHistoria!apellidos) & "," & Trim(RsHistoria!Nombres) & Space(60)
                                                   Nombre = Mid(Nombre, 1, 30)
                                                   Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                   Print #Canal, Padeo(Primero, 5) & Padeo(Segundo, 10) & Nombre & Padeo(Parcial, 7) & "00"
                                                   RsHistoria.MoveNext
                                                Wend
                                             ElseIf Control = "0508" Then ' LOTERIAS
                                                RsHistoria.MoveFirst
                                                While Not RsHistoria.EOF
                                                   Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                   Print #Canal, Primero & Padeo(RsHistoria!numerocobro, 4) & Padeo(Parcial, 5) & "00"
                                                   RsHistoria.MoveNext
                                                Wend
                                             ElseIf Control = "9604" Then ' SECUNDARIA
                                                RsHistoria.MoveFirst
                                                While Not RsHistoria.EOF
                                                   Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                   Print #Canal, Chr(34) & "V" & Chr(34) & ",0000739," & RsHistoria!cedula & "," & Chr(34) & _
                                                   Mid(RsHistoria!apellidos, 1, 1) & Chr(34) & "," & Padeo(Parcial, 6) & ".00,"
                                                   RsHistoria.MoveNext
                                                Wend
                                             ElseIf Control = "9603" Then 'UTU
                                                RsHistoria.MoveFirst
                                                While Not RsHistoria.EOF
                                                   Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                   Print #Canal, Mid(Presupuesto, 4) & Mid(Presupuesto, 1, 2) & Mid(RsHistoria!cedula, 1, 7) & _
                                                   Padeo(Parcial, 8) & "00" & "2764"
                                                   RsHistoria.MoveNext
                                                Wend
                                            ElseIf Control = "9610" Then ' UTU ESTE ES EL QUE VA A QUEDAR EN UN FUTURO NO EL ANTERIOR 29/10/2010
                                                   RsHistoria.MoveFirst
                                                   Print #Canal, Primero
                                                   While Not RsHistoria.EOF
                                                   ',11698947,,739,0000005000, IACOVAZZO IZMENDI M
                                                   'Modificado 19/05/2010 segun instrucciones del Codicen - Cambio de registro
                                                       Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                       'Print #Canal, "1," & RsHistoria!cedula & "," & RsHistoria!numerocobro & ",739," & Parcial & "00," & RsHistoria!apellidos
                                                       Print #Canal, "," & RsHistoria!cedula & ",,276," & Padeo(Parcial, 8) & "00," & RsHistoria!apellidos
                                                       RsHistoria.MoveNext
                                                   Wend

                                            ElseIf Control = "9602" Then ' CODICEN
                                                   RsHistoria.MoveFirst
                                                   Print #Canal, Primero
                                                   While Not RsHistoria.EOF
                                                   ',11698947,,739,0000005000, IACOVAZZO IZMENDI M
                                                   'Modificado 19/05/2010 segun instrucciones del Codicen - Cambio de registro
                                                       Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                       'Print #Canal, "1," & RsHistoria!cedula & "," & RsHistoria!numerocobro & ",739," & Parcial & "00," & RsHistoria!apellidos
                                                       Print #Canal, "," & RsHistoria!cedula & ",,739," & Padeo(Parcial, 8) & "00," & RsHistoria!apellidos
                                                       RsHistoria.MoveNext
                                                   Wend
                                             ElseIf Control = "9601" Then  ' CONSEJO EDUCACION PRIMARIA
                                                   RsHistoria.MoveFirst
                                                   While Not RsHistoria.EOF
                                                       Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                       Nombre = Trim(RsHistoria!apellidos) & " " & Trim(RsHistoria!Nombres) & Space(60)
                                                       Nombre = Mid(Nombre, 1, 25)
                                                       Primero = Padeo(RsHistoria!departamento, 2)
                                                       Segundo = Padeo(RsHistoria!numerocobro, 5)
                                                       Print #Canal, Primero & Segundo & Nombre & Padeo(Parcial, 5) & "00" & Mid(RsHistoria!ingreso, 4, 2) & _
                                                       Mid(RsHistoria!ingreso, 7)
                                                       RsHistoria.MoveNext
                                                   Wend
                                                ElseIf Control = "2002" Then  ' INTENDENCIA DE CANELONES
                                                   RsHistoria.MoveFirst
                                                   While Not RsHistoria.EOF
                                                       Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                       Nombre = Trim(RsHistoria!Nombres) & " " & Trim(RsHistoria!apellidos)
                                                       Nombre = Mid(Nombre, 1, 40)
                                                       Nombre = PadeoBlancos(Nombre, 40)
                                                       MesAño = Mid(Presupuesto, 1, 2) & Mid(Presupuesto, 4)
                                                       MesAño = Padeo(MesAño, 6)
                                                       Primero = Padeo(RsHistoria!cedula, 8)
                                                       Print #Canal, Primero & Nombre & Padeo(Parcial, 6) & "00" & MesAño
                                                       RsHistoria.MoveNext
                                                   Wend
                                                ElseIf Control = "2609" Then  ' FACULTAD DE ODONTOLOGIA
                                                   While Not RsHistoria.EOF
                                                       Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                       Nombre = Trim(RsHistoria!Nombres) & " " & Trim(RsHistoria!apellidos) & Space(60)
                                                       Nombre = Mid(Nombre, 1, 24)
                                                       Nombre = PadeoBlancos(Nombre, 24)
                                                       MesAño = Mid(Presupuesto, 1, 2) & Mid(Presupuesto, 4)
                                                       MesAño = Padeo(MesAño, 6)
                                                       Primero = RsHistoria!observaciones
                                                       Print #Canal, Primero & Padeo(RsHistoria!numerocobro, 6) & Padeo(Parcial, 6) & "00" & "         " & Nombre & Padeo(RsHistoria!cedula, 8)
                
                                                       RsHistoria.MoveNext
        
                                                   Wend
                                                ElseIf Control = "2615" Then  ' HOSPITAL DE CLINICAS
                                                   While Not RsHistoria.EOF
                                                       Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                       Nombre = Trim(RsHistoria!Nombres) & " " & Trim(RsHistoria!apellidos) & Space(60)
                                                       Nombre = Mid(Nombre, 1, 24)
                                                       Nombre = PadeoBlancos(Nombre, 24)
                                                       MesAño = Mid(Presupuesto, 1, 2) & Mid(Presupuesto, 4)
                                                       MesAño = Padeo(MesAño, 6)
                                                       Primero = RsHistoria!observaciones
                                                       Print #Canal, Primero & Padeo(RsHistoria!numerocobro, 6) & Padeo(Parcial, 6) & "00" & "         " & Nombre & Padeo(RsHistoria!cedula, 8)
                
                                                       RsHistoria.MoveNext
        
                                                   Wend

                                                ElseIf Control = "3001" Then  ' ANTEL
                                                   While Not RsHistoria.EOF
                                                       Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                       MesAño = Mid(Presupuesto, 1, 2)
                                                       MesAño = Padeo(MesAño, 2)
                                                       Print #Canal, MesAño & Padeo(Mid(RsHistoria!cedula, 1, 7), 7) & "B20" & Padeo(Parcial, 8) & "00"
                
                                                       RsHistoria.MoveNext
        
                                                   Wend

                                                ElseIf Control = "0406" Then  ' JEFATURA DE POLICIA DE CANELONES
                                                   While Not RsHistoria.EOF
                                                       Parcial = Format(RsHistoria!ImporteCuota + RsHistoria!aportecapital + RsHistoria!Excedido + RsHistoria!Mora + RsHistoria!IvaMora, "###,##0")
                                                       Print #Canal, Primero & Padeo(Mid(RsHistoria!cedula, 1, 7), 15) & Padeo(Parcial, 6) & "00" & "0000"
                                                       RsHistoria.MoveNext

                                                   Wend

                                             End If
  
                                          Close #Canal
   
                                          If Control = "0505" Then 'totales DGI
      
                                             'Open "A:\CONTROL.TXT" For Output As #Canal
                                             Open Unidad & "CONTROL.TXT" For Output As #Canal
                                             Print #Canal, "T02" & Mid(Presupuesto, 1, 2) & Mid(Presupuesto, 4) & _
                                             "0000000" & Padeo(CantidadGente, 3) & Padeo(Total, 10) & "00"
                                             Close #Canal
                                          ElseIf Oficina = "99" Then 'totales BPS
                                             Open Unidad & "Tot685" & Primero & ".dat" For Output As #Canal
                                             Print #Canal, Primero & "0006685" & Padeo(CantidadGente, 7) & Padeo(Total, 10)
                                             Close #Canal
                                          End If
      
                                          Set RsHistoria = Nothing
                                          Set RsSocios = Nothing
                                          Set RsIncisos = Nothing
                                          Set RsOficinas = Nothing
                                          If NombreArchivo = "NoHayCodigos" Then
                                             MsgBox "Ha seleccionado una Oficina" & Chr(13) _
                                             & "que no tiene retención por disco", vbOKOnly + vbInformation, Me.Caption
                                          End If
                                          MsgBox "Disco Finalizado.", vbOKOnly + vbInformation, "Inciso:" & WInciso & " Oficina:" & Oficina
                                          Exit Sub
   
                                       escribo_error:


    
                                          Set RsHistoria = Nothing
                                          Set RsSocios = Nothing
                                          Set RsIncisos = Nothing
                                          Set RsOficinas = Nothing
                                          Close #Canal
                                          Dim Contesta As Integer
                                          Screen.MousePointer = 0
                                          Contesta = Manejo_Error(Err.Number)
   
                                          Select Case Contesta
                                             Case vbAbort
                                                Exit Sub
                                             Case vbRetry
                                                Resume
                                             Case vbIgnore
                                                Resume Next
                                          End Select
   
                                       End Sub
                                               */
        }


        public string validoCedula(string cedula)
        {
            int[] digitos = new int[7];
            int[] multipli = new int[7];
            int calculo = 0;
            int controldigito;
            int compara = 0;

            multipli[0] = 2;
            multipli[1] = 9;
            multipli[2] = 8;
            multipli[3] = 7;
            multipli[4] = 6;
            multipli[5] = 3;
            multipli[6] = 4;

            for (int i = 0; i < 7; i++)
            {
                digitos[i] = Convert.ToInt32(cedula.Substring(i, 1));
                calculo = calculo + digitos[i] * multipli[i];
            }

            controldigito = (calculo - (calculo / 10) * 10);

            if (controldigito == 0)
            {
                compara = controldigito;
            }
            else
            {
                compara = 10 - controldigito;
            }

            return compara.ToString();
        }

        public bool controlarVencimiento()
        {
            DateTime fechaVencimiento;
            DateTime fechaActual = DateTime.Today;

            fechaVencimiento = DateTime.ParseExact(VariablesGlobales.Vencimiento, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            fechaActual = DateTime.ParseExact(fechaActual.ToString("yyyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);

            if (fechaVencimiento < fechaActual)
            {
                return false;
            }
            return true;
        }

        public void LoguearUsuario(string usuario, string clave)
        {
            Usuario tmpUsuario = new Usuario();
            tmpUsuario.Alias = usuario;
            tmpUsuario.Clave = clave;
            tmpUsuario.LoguearUsuario();
        }

        public DataSet DevolverAcciones()
        {
            Accion tmpAccion = new Accion();
            DataSet acciones = tmpAccion.DevolverTodos();
            return acciones;
        }

        public DataSet DevolverAccionesXUsuario(int idUsuario)
        {
            Accion tmpAccion = new Accion();
            DataSet acciones = tmpAccion.DevolverAccionesXUsuario(idUsuario);
            return acciones;
        }

        public DataSet devolverBusquedaInterfaz(string Busqueda)
        {
            Historia tmpHistoria = new Historia();
            DataSet historias = tmpHistoria.devolverBusquedaInterfaz(Busqueda);
            return historias;
        }

        public void AltaUsuario(string alias, string clave, string correo, string telefono, ArrayList acciones)
        {
            Usuario tmpUsuario = new Usuario();
            tmpUsuario.Alias = alias;
            tmpUsuario.Clave = clave;
            tmpUsuario.Correo = correo;
            tmpUsuario.Telefono = telefono;
            tmpUsuario.AccionesPermitidas = acciones;
            tmpUsuario.Guardar();
        }

        public void AltaInciso(string Codigo, string Nombre, string Abreviatura)
        {
            Inciso tmpInciso = new Inciso();
            tmpInciso.Inciso_codigo = Codigo;
            tmpInciso.Inciso_nombre = Nombre;
            tmpInciso.Inciso_abreviatura = Abreviatura;
            tmpInciso.Guardar();
        }

        public void AltaBanco(string nombrebanco, string agenciabanco, string direccionbanco, string telefonobanco, string faxbanco, string numerocta, string moneda)
        {
            Banco tmpBanco = new Banco();
            tmpBanco.Nombrebanco = nombrebanco;
            tmpBanco.Agenciabanco = agenciabanco;
            tmpBanco.Direccionbanco = direccionbanco;
            tmpBanco.Telefonobanco = telefonobanco;
            tmpBanco.Faxbanco = faxbanco;
            tmpBanco.Numerocta = numerocta;
            tmpBanco.Moneda = moneda;
            tmpBanco.Guardar();
        }

        public void actualizarSaldo(int codigobanco, Double saldo)
        {
            Banco tmpBanco = new Banco();
            tmpBanco.Codigobanco = codigobanco;
            tmpBanco.Saldo = saldo;
            tmpBanco.actualizarSaldo();
        }

        public void AltaMovimiento(DateTime fecha, int codigobanco, string numerocta, string numerodocumento, string debehaber, Double importe, string concepto, Double saldo)
        {
            Movimiento tmpMovimiento = new Movimiento();
            tmpMovimiento.Fecha = fecha;
            tmpMovimiento.Codigobanco = codigobanco;
            tmpMovimiento.Numerocta = numerocta;
            tmpMovimiento.Numerodocumento = numerodocumento;
            tmpMovimiento.Debehaber = debehaber;
            tmpMovimiento.Importe = importe;
            tmpMovimiento.Concepto = concepto;
            tmpMovimiento.Saldo = saldo;

            tmpMovimiento.Guardar();
        }

        public void AltaOficina(string codigo, string nombre, string abreviatura, string direccion, int idInciso, int idDepartamento, string codigoPostal, string telefono, string email, string nombreContacto)
        {
            Oficina tmpOficina = new Oficina();

            Inciso tmpInciso = new Inciso();
            tmpInciso.Inciso_id = idInciso;

            Departamento tmpDepartamento = new Departamento();
            tmpDepartamento.Departamento_id = idDepartamento;

            tmpOficina.Oficina_codigo = codigo;
            tmpOficina.Oficina_nombre = nombre;
            tmpOficina.Oficina_abreviatura = abreviatura;
            tmpOficina.Oficina_direccion = direccion;
            tmpOficina.Oficina_inciso = tmpInciso;
            tmpOficina.Departamento = tmpDepartamento;
            tmpOficina.Oficina_codigopostal = codigoPostal;
            tmpOficina.Oficina_telefono = telefono;
            tmpOficina.Oficina_email = email;
            tmpOficina.Oficina_nombrecontacto = nombreContacto;
            tmpOficina.Guardar();
        }

        public void AltaEmpresa(String empresa_nombre, String empresa_sigla, String empresa_direccion, String empresa_departamento,
            String empresa_codigoPostal, string empresa__telefono, string empresa_fax, String empresa_rut,
            int empresa_aporte, int empresa_MaxUnidad, int empresa_iva, int empresa_intMora,
            string empresa_mail, string empresa_presidente, string empresa__tesorero, string empresa_secretario,
            string empresa_primerVocal, string empresa_segundoVocal, DateTime empresa_fechaEleccion)
        {
            Empresa tmpEmpresa = new Empresa();

            tmpEmpresa.Empresa_nombre = empresa_nombre;
            tmpEmpresa.Empresa_sigla = empresa_sigla;
            tmpEmpresa.Empresa_direccion = empresa_direccion;
            tmpEmpresa.Empresa_departamento = empresa_departamento;
            tmpEmpresa.Empresa_codigoPostal = empresa_codigoPostal;
            tmpEmpresa.Empresa__telefono = empresa__telefono;
            tmpEmpresa.Empresa_fax = empresa_fax;
            tmpEmpresa.Empresa_rut = empresa_rut;
            tmpEmpresa.Empresa_aporte = empresa_aporte;
            tmpEmpresa.Empresa_MaxUnidad = empresa_MaxUnidad;

            tmpEmpresa.Empresa_iva = empresa_iva;
            tmpEmpresa.Empresa_intMora = empresa_intMora;
            tmpEmpresa.Empresa_mail = empresa_mail;
            tmpEmpresa.Empresa_presidente = empresa_presidente;
            tmpEmpresa.Empresa__tesorero = empresa__tesorero;
            tmpEmpresa.Empresa_secretario = empresa_secretario;
            tmpEmpresa.Empresa_primerVocal = empresa_primerVocal;
            tmpEmpresa.Empresa_segundoVocal = empresa_segundoVocal;
            tmpEmpresa.Empresa_fechaEleccion = empresa_fechaEleccion;

            tmpEmpresa.Guardar();
        }

        public void modificarInciso(string Codigo, string Nombre, string Abreviatura, int idInciso)
        {
            Inciso tmpInciso = new Inciso();
            if (idInciso == 0)
                throw new Exception("Id del inciso no puede ser 0");

            tmpInciso.Inciso_codigo = Codigo;
            tmpInciso.Inciso_nombre = Nombre;
            tmpInciso.Inciso_abreviatura = Abreviatura;
            tmpInciso.Inciso_id = idInciso;
            tmpInciso.modificarInciso();
        }

        public void modificarBanco(string nombrebanco, string agenciabanco, string direccionbanco, string telefonobanco, string faxbanco, string numerocta, string moneda, int codigobanco)
        {
            Banco tmpBanco = new Banco();
            if (codigobanco == 0)
                throw new Exception("Id del banco no puede ser 0");

            tmpBanco.Nombrebanco = nombrebanco;
            tmpBanco.Agenciabanco = agenciabanco;
            tmpBanco.Direccionbanco = direccionbanco;
            tmpBanco.Telefonobanco = telefonobanco;
            tmpBanco.Faxbanco = faxbanco;
            tmpBanco.Numerocta = numerocta;
            tmpBanco.Moneda = moneda;
            tmpBanco.Codigobanco = codigobanco;
            tmpBanco.modificarBanco();
        }

        public void actualizarExcedidoCierre(int idExcedido, DateTime fechadepago, double importepagado, String presupuestodelpago)
        {
            Excedidos tmpExcedido = new Excedidos();
            tmpExcedido._idExcedido = idExcedido;
            tmpExcedido._fechadepago = fechadepago;
            tmpExcedido._importepagado = importepagado;
            tmpExcedido._presupuestodelpago = presupuestodelpago;
            tmpExcedido.actualizarExcedidoCierre();
        }

        public void modificarOficina(string codigo, string nombre, string abreviatura, string direccion, int idInciso, int idDepartamento, string codigoPostal, string telefono, string email, string nombreContacto, int idOficina)
        {
            Oficina tmpOficina = new Oficina();

            Inciso tmpInciso = new Inciso();
            tmpInciso.Inciso_id = idInciso;

            Departamento tmpDepartamento = new Departamento();
            tmpDepartamento.Departamento_id = idDepartamento;

            tmpOficina.Oficina_codigo = codigo;
            tmpOficina.Oficina_nombre = nombre;
            tmpOficina.Oficina_abreviatura = abreviatura;
            tmpOficina.Oficina_direccion = direccion;
            tmpOficina.Oficina_inciso = tmpInciso;
            tmpOficina.Departamento = tmpDepartamento;
            tmpOficina.Oficina_codigopostal = codigoPostal;
            tmpOficina.Oficina_telefono = telefono;
            tmpOficina.Oficina_email = email;
            tmpOficina.Oficina_nombrecontacto = nombreContacto;
            tmpOficina.Oficina_id = idOficina;
            tmpOficina.modificarOficina();
        }

        public DataSet DevolverUsuarios()
        {
            Usuario tmpUsuario = new Usuario();
            DataSet usuarios = tmpUsuario.devolverUsuarios();
            return usuarios;
        }

        public DataSet movimientosPromedio(int codigoBancoConsulta, int diaDesde, int diaHasta, int mes, int anio)
        {
            Movimiento tmpMovimiento = new Movimiento();
            DataSet consulta = tmpMovimiento.movimientosPromedio(codigoBancoConsulta, diaDesde, diaHasta, mes, anio);
            return consulta;
        }

        public DataSet DevolverHistoria()
        {
            Historia tmpHistoria = new Historia();
            DataSet historias = tmpHistoria.devolverHistoria();
            return historias;
        }

        public DataSet devolverHistoriaPorIDyPresupuesto(int idSocio, string presupuesto)
        {
            Historia tmpHistoria = new Historia();
            DataSet historias = tmpHistoria.devolverHistoriaPorIDyPresupuesto(idSocio, presupuesto);
            return historias;
        }

        public DataSet devolverHistoriaPorIdSocio(int idSocio)
        {
            Historia tmpHistoria = new Historia();
            DataSet historias = tmpHistoria.devolverHistoriaPorIdSocio(idSocio);
            return historias;
        }

        public void GuardarHistoria(string _Presupuesto, int _NumeroPrestamo, string _cedula, double _tasa, double _porcentajeiva,
            double _montopedido, double _cantidadcuotas, double _nrodecuotas, double _importecuota, double _AmortizacionCuota, double _InteresCuota, double _IvaCuota,
            double _AmortizacionVencer, double _InteresVencer, double _aportecapital, string _numerocobro, int _Inciso, int _oficina, double _excedido, double _mora,
            double _IvaMora, int socio_id)
        {
            Historia tmpHistoria = new Historia();

            tmpHistoria._Presupuesto = _Presupuesto;
            tmpHistoria._NumeroPrestamo = _NumeroPrestamo;
            tmpHistoria._cedula = _cedula;
            tmpHistoria._tasa = _tasa;
            tmpHistoria._porcentajeiva = _porcentajeiva;
            tmpHistoria._montopedido = _montopedido;
            tmpHistoria._cantidadcuotas = _cantidadcuotas;
            tmpHistoria._nrodecuotas = _nrodecuotas;
            tmpHistoria._importecuota = _importecuota;
            tmpHistoria._AmortizacionCuota = _AmortizacionCuota;
            tmpHistoria._InteresCuota = _InteresCuota;
            tmpHistoria._IvaCuota = _IvaCuota;
            tmpHistoria._AmortizacionVencer = _AmortizacionVencer;
            tmpHistoria._InteresVencer = _InteresVencer;
            tmpHistoria._aportecapital = _aportecapital;
            tmpHistoria._numerocobro = _numerocobro;
            tmpHistoria._Inciso = _Inciso;
            tmpHistoria._oficina = _oficina;
            tmpHistoria._excedido = _excedido;
            tmpHistoria._mora = _mora;
            tmpHistoria._IvaMora = _IvaMora;
            tmpHistoria._socio_id = socio_id;
            tmpHistoria.Guardar();
        }

        public DataSet DevolverIncisos()
        {
            Inciso tmpInciso = new Inciso();
            DataSet incisos = tmpInciso.devolverIncisos();
            return incisos;
        }

        public DataSet DevolverBancos()
        {
            Banco tmpBanco = new Banco();
            DataSet bancos = tmpBanco.devolverBancos();
            return bancos;
        }

        public DataSet DevolverCobranzas()
        {
            Cobranza tmpCobranza = new Cobranza();
            DataSet cobranzas = tmpCobranza.devolverCobranzas();
            return cobranzas;
        }

        public DataSet DevolverCobranzasProvisorias()
        {
            CobranzaProvisoria tmpCobranzaProvisoria = new CobranzaProvisoria();
            DataSet cobranzasProvisoria = tmpCobranzaProvisoria.devolverCobranzasProvisorias();
            return cobranzasProvisoria;
        }

        public DataSet DevolverEmpresa()
        {
            Empresa tmpInciso = new Empresa();
            DataSet empresas = tmpInciso.devolverEmpresa();
            return empresas;
        }

        public DataSet DevolverDepartamentos()
        {
            Departamento tmpDepartamento = new Departamento();
            DataSet departamentos = tmpDepartamento.devolverDepartamentos();
            return departamentos;
        }

        public DataSet DevolverOficinas()
        {
            Oficina tmpOficina = new Oficina();
            DataSet oficinas = tmpOficina.devolverOficinas();
            return oficinas;
        }

        public DataSet DevolverOficinasPorInciso(int idInciso)
        {
            Oficina tmpOficina = new Oficina();
            DataSet oficinasInciso = tmpOficina.devolverOficinasPorInciso(idInciso);
            return oficinasInciso;
        }

        public DataSet DevolverSocios()
        {
            Socio tmpSocio = new Socio();
            DataSet socios = tmpSocio.devolverSocios();
            return socios;
        }

        public DataSet devolverTodosBusqueda(string campo)
        {
            Socio tmpSocio = new Socio();
            DataSet socios = tmpSocio.devolverTodosBusqueda(campo);
            return socios;
        }

        public DataSet devolverBajasEntreFechas(DateTime fechaInicial, DateTime fechaFinal)
        {
            Socio tmpSocio = new Socio();
            DataSet socios = tmpSocio.devolverBajasEntreFechas(fechaInicial, fechaFinal);
            return socios;
        }

        public DataSet devolverIngresadosEntreFechas(DateTime fechaInicial, DateTime fechaFinal)
        {
            Socio tmpSocio = new Socio();
            DataSet socios = tmpSocio.devolverIngresadosEntreFechas(fechaInicial, fechaFinal);
            return socios;
        }

        public DataSet listadoSociosDepartamento(String signo, String departamento)
        {
            Socio tmpSocio = new Socio();
            DataSet socios = tmpSocio.listadoSociosDepartamento(signo, departamento);
            return socios;
        }

        public DataSet devolverCumpleMes(int mes)
        {
            Socio tmpSocio = new Socio();
            DataSet socios = tmpSocio.devolverCumpleMes(mes);
            return socios;
        }

        public DataSet devolverSociosSegunEstado(int estado) // 1 = activo 0 = historico o baja
        {
            Socio tmpSocio = new Socio();
            DataSet socios = tmpSocio.devolverSociosSegunEstado(estado);
            return socios;
        }

        public DataSet devolverSocioId(int id_socio)
        {
            Socio tmpSocio = new Socio();
            DataSet socioId = tmpSocio.devolverSocioId(id_socio);
            return socioId;
        }


        public DataSet DevolverSociosActivos()
        {
            Socio tmpSocio = new Socio();
            DataSet socios = tmpSocio.devolverSociosActivos();
            return socios;
        }

        public void bajaPlan(int idPlan)
        {
            Plan tmpPlan = new Plan();
            //if (idPlan == 0)
            //    throw new Exception("Id del usuario no puede ser 0");

            tmpPlan.Plan_id = idPlan;
            tmpPlan.eliminar();
        }

        public void eliminarAmortizacionVencerCeroCobranza()
        {
            Cobranza tmpCobranza = new Cobranza();
            tmpCobranza.eliminarAmortizacionVencerCero();
        }




        public void bajaSocio(int idSocio, ref int estadoActual)
        {
            Socio tmpSocio = new Socio();
            //revisar que el socio no tenga prestamos activos  (pendiente)
            tmpSocio.Socio_id = idSocio;
            tmpSocio.eliminar(ref estadoActual);

        }

        public void buscarSocio(string socioNro)
        {
            Socio tmpSocio = new Socio();
            //revisar que el socio no tenga prestamos activos  (pendiente)
            tmpSocio.Socio_nro = socioNro;
            tmpSocio.buscar();

        }

        public DataSet buscarSociosPorCampo(string campo, string valor)
        {
            Socio tmpSocio = new Socio();
            DataSet socios = tmpSocio.buscarSociosPorCampo(campo, valor);
            return socios;
        }

        public void bajaInciso(int idInciso)
        {
            Inciso tmpInciso = new Inciso();
            if (idInciso == 0)
                throw new Exception("Id del inciso no puede ser 0");

            tmpInciso.Inciso_id = idInciso;
            tmpInciso.eliminar();
        }

        public void bajaBanco(int codigoBanco)
        {
            Banco tmpBanco = new Banco();
            if (codigoBanco == 0)
                throw new Exception("Id del banco no puede ser 0");

            tmpBanco.Codigobanco = codigoBanco;
            tmpBanco.eliminar();
        }

        public void bajaOficina(int idOficina)
        {
            Oficina tmpOficina = new Oficina();
            if (idOficina == 0)
                throw new Exception("Id de oficina no puede ser 0");

            tmpOficina.Oficina_id = idOficina;
            tmpOficina.eliminar();
        }

        public DataSet DevolverPlanes()
        {
            Plan tmpPlan = new Plan();
            DataSet planes = tmpPlan.devolverPlanes();
            return planes;
        }

        public DataSet devolverPrestamosOtorgadosPresupuesto(string presupuesto)
        {
            Historia tmpHistoria = new Historia();
            DataSet historias = tmpHistoria.devolverPrestamosOtorgadosPresupuesto(presupuesto);
            return historias;
        }

        public DataSet devolverPresupuestoDelMes(string presupuesto)
        {
            Historia tmpHistoria = new Historia();
            DataSet historias = tmpHistoria.devolverPresupuestoDelMes(presupuesto);
            return historias;
        }

        public DataSet DevolverFechasCierres()
        {
            FechaCierre tmpFechaCierre = new FechaCierre();
            DataSet fechasCierres = tmpFechaCierre.devolverTodos();
            return fechasCierres;
        }

        public DataSet DevolverPlanesActivos()
        {
            Plan tmpPlan = new Plan();
            DataSet planes = tmpPlan.devolverActivos();
            return planes;
        }
        public void AltaPlan(int Plan_cantCuotas, double Plan_TasaAnualEfectiva, double Plan_IvaSobreIntereses, int Plan_vigencia, string Plan_nombre, double Plan_CuotaCada1000)
        {
            Plan tmpPlan = new Plan();
            tmpPlan.Plan_cantCuotas = Plan_cantCuotas;
            tmpPlan.Plan_TasaAnualEfectiva = Plan_TasaAnualEfectiva;
            tmpPlan.Plan_IvaSobreIntereses = Plan_IvaSobreIntereses;
            tmpPlan.Plan_vigencia = Plan_vigencia;
            tmpPlan.Plan_nombre = Plan_nombre;
            tmpPlan.Plan_CuotaCada1000 = Plan_CuotaCada1000;
            tmpPlan.Guardar();
        }

        public void ModificarPlan(int id_plan, int Plan_cantCuotas, double Plan_TasaAnualEfectiva, double Plan_IvaSobreIntereses, int Plan_vigencia, string Plan_nombre, double Plan_CuotaCada1000)
        {
            Plan tmpPlan = new Plan();
            tmpPlan.Plan_id = id_plan;
            tmpPlan.Plan_cantCuotas = Plan_cantCuotas;
            tmpPlan.Plan_TasaAnualEfectiva = Plan_TasaAnualEfectiva;
            tmpPlan.Plan_IvaSobreIntereses = Plan_IvaSobreIntereses;
            tmpPlan.Plan_vigencia = Plan_vigencia;
            tmpPlan.Plan_nombre = Plan_nombre;
            tmpPlan.Plan_CuotaCada1000 = Plan_CuotaCada1000;
            tmpPlan.modificarPlan();
        }

        public void BajaUsuario(int idUsuario)
        {
            Usuario tmpUsuario = new Usuario();
            if (idUsuario == 0)
                throw new Exception("Id del usuario no puede ser 0");

            tmpUsuario.Id = idUsuario;
            tmpUsuario.eliminarUsuario();
        }

        public void BajaEvento(int idEvento)
        {
            Evento tmpEvento = new Evento();
            if (idEvento == 0)
                throw new Exception("Id del evento no puede ser 0");

            tmpEvento.Id = idEvento;
            tmpEvento.eliminarEvento();
        }

        public void modificarEvento(DateTime fecha, string descripcion, int idEvento)
        {
            Evento tmpEvento = new Evento();
            if (idEvento == 0)
                throw new Exception("Id del evento no puede ser 0");

            tmpEvento.Id = idEvento;
            tmpEvento.Fecha = fecha;
            tmpEvento.Descripcion = descripcion;
            tmpEvento.modificarEvento();
        }

        public void ModificarClaveUsuario(int idUsuario, string claveAnterior, string claveNueva)
        {
            Usuario tmpUsuario = new Usuario();
            tmpUsuario.Id = idUsuario;
            tmpUsuario.Clave = claveNueva;
            tmpUsuario.ModificarClave(claveAnterior);
        }

        public string ResetearClaveUsuario(int idUsuario)
        {
            Usuario tmpUsuario = new Usuario();
            tmpUsuario.Id = idUsuario;
            string claveNueva = tmpUsuario.ResetearClave();
            return claveNueva;
        }

        public void ModificarUsuario(int idUsuario, string alias, string correo, string telefono, ArrayList acciones)
        {
            Usuario tmpUsuario = new Usuario();
            tmpUsuario.Id = idUsuario;
            tmpUsuario.Alias = alias;
            tmpUsuario.Correo = correo;
            tmpUsuario.Telefono = telefono;
            tmpUsuario.AccionesPermitidas = acciones;

            tmpUsuario.Modificar();
        }

        public void guardarEvento(DateTime fecha, string descripcion)
        {
            Evento tmpEvento = new Evento();
            tmpEvento.Descripcion = descripcion;
            tmpEvento.Fecha = fecha;
            tmpEvento.Guardar();
        }

        public DataSet DevolverEventos(DateTime fecha)
        {
            Evento tmpEvento = new Evento();
            DataSet eventos = tmpEvento.devolverEventos(fecha);
            return eventos;
        }

        public DataSet DevolverEvento(int idEvento)
        {
            Evento tmpEvento = new Evento();
            DataSet evento = tmpEvento.devolverEvento(idEvento);
            return evento;
        }

        public DataSet devolverEventosEntreFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            Evento tmpEvento = new Evento();
            return tmpEvento.devolverEventosEntreFechas(fechaDesde, fechaHasta);
        }

        public void VaciarTablaCobranzaProvisoria()
        {
            CobranzaProvisoria tmpCobranzaProvisoria = new CobranzaProvisoria();
            tmpCobranzaProvisoria.VaciarTablaCobranzaProvisoria();
        }

        public void eliminarCobranzaProvisoria(int Id)
        {
            CobranzaProvisoria tmpCobranzaProvisoria = new CobranzaProvisoria();
            tmpCobranzaProvisoria.eliminarCobranzaProvisoria(Id);
        }

        public void AltaSocio(int socioActivo, string NroSocio, string NroCobro, string Nombres, string Apellidos, DateTime FechaNacimiento, DateTime FechaIngreso,
            string EstadoCivil, char sexo, string estado, int edad, int OficinaId, int IncisoId, string tel, string direccion, string email, string postal, String departamento, String mostrarDetalles)
        {
            Socio tmpSocio = new Socio();
            tmpSocio.Socio_nro = NroSocio;
            tmpSocio.Socio_nroCobro = NroCobro;
            tmpSocio.Socio_nombre = Nombres;
            tmpSocio.Socio_apellido = Apellidos;
            tmpSocio.Socio_fechaNac = FechaNacimiento;
            tmpSocio.Socio_fechaIngreso = FechaIngreso;
            tmpSocio.Socio_estadoCivil = EstadoCivil;
            tmpSocio.Socio_sexo = sexo;
            tmpSocio.Socio_estado = estado;
            tmpSocio.Socio_edad = edad;
            tmpSocio.Socio_oficinaId = OficinaId;
            tmpSocio.Socio_incisoId = IncisoId;
            tmpSocio.Socio_tel = tel;
            tmpSocio.Socio_direccion = direccion;
            tmpSocio.Socio_email = email;
            tmpSocio.Socio_activo = socioActivo;
            tmpSocio.Detalles = mostrarDetalles;
            tmpSocio.Socio_postal = postal;
            tmpSocio.Departamento = departamento;
            tmpSocio.Guardar();
        }

        public void EditarSocio(int Tsocio_id, string NroSocio, string NroCobro, string Nombres, string Apellidos, DateTime FechaNacimiento, DateTime FechaIngreso,
            string EstadoCivil, char sexo, string estado, int edad, int OficinaId, int IncisoId, string tel, string direccion, string email, string postal, string departamento, string detalles)
        {
            Socio tmpSocio = new Socio();
            tmpSocio.Socio_nro = NroSocio;
            tmpSocio.Socio_nroCobro = NroCobro;
            tmpSocio.Socio_nombre = Nombres;
            tmpSocio.Socio_apellido = Apellidos;
            tmpSocio.Socio_fechaNac = FechaNacimiento;
            tmpSocio.Socio_fechaIngreso = FechaIngreso;
            tmpSocio.Socio_estadoCivil = EstadoCivil;
            tmpSocio.Socio_sexo = sexo;
            tmpSocio.Socio_estado = estado;
            tmpSocio.Socio_edad = edad;
            tmpSocio.Socio_oficinaId = OficinaId;
            tmpSocio.Socio_incisoId = IncisoId;
            tmpSocio.Socio_tel = tel;
            tmpSocio.Socio_direccion = direccion;
            tmpSocio.Socio_email = email;
            tmpSocio.Socio_id = Tsocio_id;
            tmpSocio.Detalles = detalles;
            tmpSocio.Socio_postal = postal;
            tmpSocio.Departamento = departamento;
            tmpSocio.ModificarSocio();
        }

        //********************************************* PRESTAMOS***********************************
        public string ESCNUM(string numero)
        {
            /*        '============================================================
                       FUNCION QUE CONVIERTE UN NUMERO DE SU FORMATO NATURAL A ESE
                       NUMERO EN LETRAS
                       SINTAXIS >> ESCNUM(NUMERO A CONVERTIR) <<
                       EL NUMERO A CONVERTIR PUEDE SER HASTA 999.999.999,99
                     ============================================================
            */

            string[] R = new string[19];
            string[] S = new string[11];
            string[] T = new string[12];
            string[] c = new string[19];

            String cont_n, VEC_P = "", a, b, retorna;
            Int32 M, N, P, i, Decim;
            Boolean SinEntero = true;


            R[1] = "UN ";
            R[2] = "DOS ";
            R[3] = "TRES ";
            R[4] = "CUATRO ";
            R[5] = "CINCO ";
            R[6] = "SEIS ";
            R[7] = "SIETE ";
            R[8] = "OCHO ";
            R[9] = "NUEVE ";
            R[10] = "DIEZ ";
            R[11] = "ONCE ";
            R[12] = "DOCE ";
            R[13] = "TRECE ";
            R[14] = "CATORCE ";
            R[15] = "QUINCE ";
            R[16] = "UNO ";
            R[17] = "MIL ";
            R[18] = "VEINTE ";
            S[1] = "CIENTO ";
            S[2] = "DOSCIENTOS ";
            S[3] = "TRESCIENTOS ";
            S[4] = "CUATROCIENTOS ";
            S[5] = "QUINIENTOS ";
            S[6] = "SEISCIENTOS ";
            S[7] = "SETECIENTOS ";
            S[8] = "OCHOCIENTOS ";
            S[9] = "NOVECIENTOS ";
            S[10] = "CIEN ";
            T[1] = "DIECI";
            T[2] = "VEINTI";
            T[3] = "TREINTA ";
            T[4] = "CUARENTA ";
            T[5] = "CINCUENTA ";
            T[6] = "SESENTA ";
            T[7] = "SETENTA ";
            T[8] = "OCHENTA ";
            T[9] = "NOVENTA ";
            T[10] = "MILLONES ";
            T[11] = "MILLON ";

            M = 0; //  DECENAS DE MILLONES
            N = 0; //  DECENAS DE MILES
            P = 0; //  DECENAS
            i = 0;

            cont_n = Convert.ToDouble(numero).ToString("000000000.00");

            for (i = 1; i <= 9; i++)
            {
                c[i] = Convert.ToString(Microsoft.VisualBasic.Conversion.Val(Microsoft.VisualBasic.Strings.Mid(cont_n, i, 1)));
            }

            M = Convert.ToInt32(Microsoft.VisualBasic.Conversion.Val(Microsoft.VisualBasic.Strings.Mid(cont_n, 2, 2)));
            N = Convert.ToInt32(Microsoft.VisualBasic.Conversion.Val(Microsoft.VisualBasic.Strings.Mid(cont_n, 5, 2)));
            P = Convert.ToInt32(Microsoft.VisualBasic.Conversion.Val(Microsoft.VisualBasic.Strings.Mid(cont_n, 8, 2)));
            Decim = Convert.ToInt32(Microsoft.VisualBasic.Conversion.Val(Microsoft.VisualBasic.Strings.Mid(cont_n, 11, 2)));

            if (c[1] != "0")
            {
                SinEntero = false;
                i = Convert.ToInt32(c[1]);

                if ((c[1] == "1") && (M == 0))
                {
                    VEC_P = VEC_P + S[10];
                }
                else
                {
                    VEC_P = VEC_P + S[i];
                }
            }

            if (M != 0)
            {
                SinEntero = false;
                i = Convert.ToInt32(c[2]);
                if (M < 16)
                {
                    VEC_P = VEC_P + R[M];
                }
                else if (M == 20)
                {
                    VEC_P = VEC_P + R[18];
                }
                else
                {
                    VEC_P = VEC_P + T[i];
                }
            }

            if (c[3] == "0")
            {
                SinEntero = false;
                i = Convert.ToInt32(c[3]);
                if ((M > 15) && (M < 30))
                {
                    VEC_P = VEC_P + R[i];
                }
                else if (M > 30)
                {
                    VEC_P = VEC_P + "Y " + R[i];
                }
            }

            if ((c[1] != "0") || (M != 0))
            {
                SinEntero = false;
                if ((c[1] == "0") && (M == 1))
                {
                    VEC_P = VEC_P + T[11];
                }
                else
                {
                    VEC_P = VEC_P + T[10];
                }
            }

            if (c[4] != "0")
            {
                SinEntero = false;
                i = Convert.ToInt32(c[4]);
                if ((c[4] == "1") && (N == 0))
                {
                    VEC_P = VEC_P + S[10];
                }
                VEC_P = VEC_P + S[i];
            }

            if (N != 0)
            {
                SinEntero = false;
                i = Convert.ToInt32(c[5]);
                if (N < 16)
                {
                    VEC_P = VEC_P + R[N];
                }
                else if (N == 20)
                {
                    VEC_P = VEC_P + R[18];
                }
                else
                {
                    VEC_P = VEC_P + T[i];
                }
            }

            if (c[6] != "0")
            {
                SinEntero = false;
                i = Convert.ToInt32(c[6]);
                if ((N > 15) && (N < 30))
                {
                    VEC_P = VEC_P + R[i];
                }
                else if (N > 30)
                {
                    VEC_P = VEC_P + "Y " + R[i];
                }
            }

            if ((c[4] != "0") || (N != 0))
            {
                SinEntero = false;
                VEC_P = VEC_P + R[17];
            }

            if (c[7] != "0")
            {
                SinEntero = false;
                i = Convert.ToInt32(c[7]);
                if ((c[7] == "1") && (P == 0))
                {
                    VEC_P = VEC_P + S[10];
                }
                else
                {
                    VEC_P = VEC_P + S[i];
                }
            }

            if (P != 0)
            {
                SinEntero = false;
                i = Convert.ToInt32(c[8]);
                if (P < 16)
                {
                    VEC_P = VEC_P + R[P];
                }
                else if (P == 20)
                {
                    VEC_P = VEC_P + R[18];
                }
                else
                {
                    VEC_P = VEC_P + T[i];
                }
            }

            if (c[9] != "0")
            {
                SinEntero = false;
                i = Convert.ToInt32(c[9]);
                if ((P > 15) && (P < 30))
                {
                    VEC_P = VEC_P + R[i];
                }
                else if (P > 30)
                {
                    VEC_P = VEC_P + "Y " + R[i];
                }
            }

            if ((c[7] != "0") || (P != 0))
            {
                SinEntero = false;
                if ((c[9] == "1") && (P != 11))
                {
                    VEC_P = Microsoft.VisualBasic.Strings.Trim(VEC_P) + "O ";
                }
            }

            if (SinEntero)
            {
                VEC_P = "CERO ";
            }

            a = Microsoft.VisualBasic.Strings.Mid(VEC_P, 1, 1);
            b = Microsoft.VisualBasic.Strings.LCase(Microsoft.VisualBasic.Strings.Mid(VEC_P, 2, Microsoft.VisualBasic.Strings.Len(VEC_P) - 1));

            if (Decim == 0)
            {
                retorna = Microsoft.VisualBasic.Strings.RTrim(a) + b + ".-";
            }
            else
            {
                retorna = Microsoft.VisualBasic.Strings.RTrim(a) + b + "con " + Decim + "/100.-";
            }
            return retorna;
        }

        public int AltaPrestamo(Socio socio,
                      string socio_nro,
                      DateTime fecha,
                      DateTime hora,
                      double monteopedido,
                      double tasa,
                      int cantidadcuotas,
                      double importecuota,
                      int numeroPrestamoAnt,
                      double montopedidoAnt,
                      double amortizacionVencer,
                      double interesesVencer,
                      int cuotasPactadas,
                      int cuotasPagadas,
                      double cuotaAnt,
                      double tasaanterior,
                      int anulado)
        {

            Prestamo tmpPrestamo = new Prestamo();
            tmpPrestamo.Socio = socio;
            tmpPrestamo.Socio_nro = socio_nro;
            tmpPrestamo.Fecha = fecha;
            tmpPrestamo.Hora = hora;
            tmpPrestamo.Monteopedido = monteopedido;
            tmpPrestamo.Tasa = tasa;
            tmpPrestamo.Cantidadcuotas = cantidadcuotas;
            tmpPrestamo.Importecuota = importecuota;
            tmpPrestamo.NumeroPrestamoAnt = numeroPrestamoAnt;
            tmpPrestamo.MontopedidoAnt = montopedidoAnt;
            tmpPrestamo.AmortizacionVencer = amortizacionVencer;
            tmpPrestamo.InteresesVencer = interesesVencer;
            tmpPrestamo.CuotasPactadas = cuotasPactadas;
            tmpPrestamo.CuotasPagadas = cuotasPagadas;
            tmpPrestamo.CuotaAnt = cuotaAnt;
            tmpPrestamo.Tasaanterior = tasaanterior;
            tmpPrestamo.Anulado = anulado;


            /*    if (!(tmpPrestamo.NumeroPrestamoAnt == 0))
                {
                    tmpPrestamo.anularPrestamo(tmpPrestamo.NumeroPrestamoAnt);
                }
           */

            return tmpPrestamo.Guardar();
        }

        public DateTime VtoPrimerCuota(DateTime Fecha)
        {
            DateTime VtoPrimerCuota;
            DateTime FechaNueva;

            FechaNueva = DateTime.Today.AddDays(15);

            // VEEER porque en la original se llamaba a la función UltimoDiaMes que Leo no la pasó
            VtoPrimerCuota = Convert.ToDateTime(DateTime.DaysInMonth(FechaNueva.Year, FechaNueva.Month) + "/" + FechaNueva.Month + "/" + FechaNueva.Year);

            return VtoPrimerCuota;
        }

        public DateTime VtoPto(DateTime Fecha)
        {
            DateTime VtoPto;
            if ((Microsoft.VisualBasic.Conversion.Val(Fecha.Day) <= 10))
            { //Fecha tope dentro del mes para cierre de presupuesto
                if ((Microsoft.VisualBasic.Conversion.Val(Fecha.Month) != 2))
                {
                    VtoPto = Convert.ToDateTime("30" + "/" + Fecha.Month + "/" + Fecha.Year);
                }
                else
                {
                    VtoPto = Convert.ToDateTime("28" + "/" + Fecha.Month + "/" + Fecha.Year);
                }
            }

            if ((Microsoft.VisualBasic.Conversion.Val(Fecha.Month) == 12))
            { // Si mes es igual a 12 y día mayor a 10 debe cerrar 

                VtoPto = Convert.ToDateTime("30" + "/01/" + (Fecha.Year + 1)); // El mes siguiente del año siguiente
            }
            else if ((Microsoft.VisualBasic.Conversion.Val(Fecha.Month) == 1))
            {
                VtoPto = Convert.ToDateTime("28" + "/02/" + (Fecha.Year));
            }
            else
            {
                VtoPto = Convert.ToDateTime("30" + "/" + (Fecha.Month + 1) + "/" + Fecha.Year);
            }
            return VtoPto;
        }

        public double IntVencer(double ImpCuota, int CantidadCuotas, int NroCuota, double AmoVencer)
        {

            double IntVencer;

            if ((CantidadCuotas - NroCuota) == 0)
            {
                IntVencer = 0;
            }
            else
            {
                IntVencer = Convert.ToDouble(Strings.Format(((ImpCuota * (CantidadCuotas - NroCuota)) - AmoVencer), "##########.00"));
            }
            return IntVencer;
        }

        public double Pago_Mora(double Importe, string Presupuesto, double Xmora, string QueFecha)
        {
            double Pago_Mora;

            // Importe es la base de cálculo que quedó debiendo
            // Presupuesto es el mes en que no se le pudo descontar
            // Xmora  es la tasa para cobro de mora seteado en parametros

            string Mes; // * 2;  VEEERRR
            string Año; //* 4;   VEEERRR
            DateTime FechasDesde;
            DateTime QueFechaResultado;
            int CantidadDias;
            double TasaDeCobro;

            Mes = Microsoft.VisualBasic.Strings.Mid(Presupuesto, 1, 2);
            Año = Microsoft.VisualBasic.Strings.Mid(Presupuesto, 4);
            TasaDeCobro = 0;

            if (Microsoft.VisualBasic.Conversion.Val(Mes) == 12)
            {
                FechasDesde = Convert.ToDateTime("01/01/" + (Microsoft.VisualBasic.Conversion.Val(Año) + 1));
            }
            else
            {
                FechasDesde = Convert.ToDateTime("01/" + (Microsoft.VisualBasic.Conversion.Val(Mes) + 1) + "/" + Año);
            }

            if (QueFecha != "")
            {
                QueFechaResultado = Convert.ToDateTime(QueFecha);
            }

            if (QueFecha == "") //cobranza por caja
            {
                TimeSpan ts = DateTime.Today - FechasDesde;
                CantidadDias = ts.Days;
            }
            else
            {
                TimeSpan ts = Convert.ToDateTime(QueFecha) - FechasDesde;
                CantidadDias = ts.Days;
            }

            // tasa = tasa + 100; //ejemp. 60 + 100 = 160
            // tasa = tasa / 100; //ejemp. 160 / 100 = 1.60
            // tasa = Math.Pow(tasa, (1 / 12)) - 1; //esta es la tasa mensual;

            TasaDeCobro = Xmora + 100;
            TasaDeCobro = TasaDeCobro / 100;

            TasaDeCobro = Math.Pow(TasaDeCobro, Convert.ToDouble(Decimal.Divide(CantidadDias, 360)));
            TasaDeCobro = TasaDeCobro - 1;
            Pago_Mora = Importe * TasaDeCobro;

            return Pago_Mora;
        }

        public double AmortVencer(double tasa, int CantidadCuotas, int NroCuota, double ImpCuota)
        {
            double AmortVencer;

            tasa = tasa + 100; //ejemp. 60 + 100 = 160
            tasa = tasa / 100; //ejemp. 160 / 100 = 1.60
            tasa = Math.Pow(tasa, Convert.ToDouble(Decimal.Divide(1, 12))) - 1; //esta es la tasa mensual;

            if ((CantidadCuotas - NroCuota) == 0)
            {
                AmortVencer = 0;
            }

            AmortVencer = Convert.ToDouble(Strings.Format(ImpCuota * ((1 - Math.Pow(1 / (1 + (tasa)), (CantidadCuotas - NroCuota))) / tasa), "##########.00"));

            return AmortVencer;
        }

        public double AmortCuota(double tasa, int NroCuota, int CantidadCuotas, double Capital)
        {
            double AmortCuota;

            tasa = tasa + 100; //ejemp. 60 + 100 = 160
            tasa = tasa / 100; //ejemp. 160 / 100 = 1.60
            tasa = Math.Pow(tasa, Convert.ToDouble(Decimal.Divide(1, 12))) - 1; //esta es la tasa mensual;

            AmortCuota = Convert.ToDouble(Strings.Format(Financial.PPmt(tasa, NroCuota, CantidadCuotas, -Capital, 0, 0), "##########.00"));

            return AmortCuota;
        }

        public double Cuota(double tasa, int CantidadCuotas, double Capital)
        {
            double Cuota;

            tasa = tasa + 100; //ejemp. 60 + 100 = 160
            tasa = tasa / 100; //ejemp. 160 / 100 = 1.60
            tasa = Math.Pow(tasa, Convert.ToDouble(Decimal.Divide(1, 12))) - 1; //esta es la tasa mensual;

            Cuota = Convert.ToDouble(Strings.Format(Financial.Pmt(tasa, CantidadCuotas, -Capital), "##########.00"));

            return Cuota;
        }

        public double CalculoInteres(int Dias, int NroCuotas, double tasa, double Iva)
        {
            double Wiva;
            double Wtasa;
            double InteresMensual;
            double Wdias;
            double CalculoInteres;

            Wtasa = (tasa + 100) / 100;
            Wiva = (Iva + 100) / 100;
            Wdias = Dias / 30;

            /*aclaración de parámetros
             * días días al primer vencimiento
             * Nrocuota para saber si es la primera o las consecutivas
             * tasa interes anual iva incluido
             * iva porcentaje de iva componente de la cuota 
            */

            InteresMensual = Math.Pow(Wtasa, Convert.ToDouble(Decimal.Divide(1, 12)));

            if (NroCuotas == 1)
            {
                CalculoInteres = Math.Pow(InteresMensual, Wdias);
                CalculoInteres = CalculoInteres - 1;
                CalculoInteres = (CalculoInteres / Wiva);
                return Convert.ToDouble(Strings.Format(CalculoInteres, "##.#000000"));
            }
            else
            {
                CalculoInteres = ((InteresMensual - 1) / Wiva);
                return Convert.ToDouble(Strings.Format(CalculoInteres, "##.#000000"));
            }
        }

        public double agregarleIvaAtasaAnual(double tasaAnualEfectivaSinIVA, double iva)
        {
            return (tasaAnualEfectivaSinIVA * ((iva + 100) / 100));
        }

        public DataSet devolverPrestamoActivoSocio(int idSocio)
        {
            Prestamo tmpPrestamo = new Prestamo();
            DataSet prestamoActivo = tmpPrestamo.devolverPrestamoActivoSocio(idSocio);
            return prestamoActivo;
        }

        public DataSet devolverCobranzaProvisoriaSocio(int parametro_socio_id)
        {
            CobranzaProvisoria tmpCobranzaProvisoria = new CobranzaProvisoria();
            return tmpCobranzaProvisoria.devolverCobranzaProvisoriaSocio(parametro_socio_id);
        }

        public DataSet devolverCobranzaSocio(int parametro_socio_id)
        {
            Cobranza tmpCobranzaProvisoria = new Cobranza();
            return tmpCobranzaProvisoria.devolverCobranzaSocio(parametro_socio_id);
        }

        public string formatoFechaMid4(DateTime fecha)
        {
            return Microsoft.VisualBasic.Strings.Mid((fecha).Date.ToString("dd/MM/yyyy"), 4);
        }

        public string presupuesto()
        {
            return Microsoft.VisualBasic.Strings.Mid(VtoPto(DateTime.Today).Date.ToString("dd/MM/yyyy"), 4);
        }

        public string presupuestoFecha(DateTime fecha)
        {
            return Microsoft.VisualBasic.Strings.Mid(VtoPto(fecha).Date.ToString("dd/MM/yyyy"), 4);
        }
        public void agregarAporteCapitalCobranza(int parCobranza_id, double parAporteCapital)
        {
            Cobranza tmpCobranza = new Cobranza();
            if (parCobranza_id == 0)
                throw new Exception("Id del cobranza no puede ser 0");

            tmpCobranza.Cobranza_ID = parCobranza_id;
            tmpCobranza.AporteCapital = parAporteCapital;
            tmpCobranza.agregarAporteCapitalCobranza();
        }

        public void modificarCobranza(int parCobranza_id, int parPrestamo_id, String parCedula, double parTasa, double parPorcentajeiva, double parMontopedido, int parCantidadcuotas, int parNrodecuotas, double parImportecuota, double parAmortizacioncuota, double parInteresCuota, double parIvaCuota, double parAmortizacionVencer, double parInteresVencer, double parAporteCapital, int parSocio_id)
        {
            Cobranza tmpCobranza = new Cobranza();
            if (parCobranza_id == 0)
                throw new Exception("Id del cobranza no puede ser 0");

            tmpCobranza.Cobranza_ID = parCobranza_id;
            tmpCobranza.Prestamo_id = parPrestamo_id;
            tmpCobranza.Socio_nro = parCedula;
            tmpCobranza.Tasa = parTasa;
            tmpCobranza.Porcentajeiva = parPorcentajeiva;
            tmpCobranza.Monteopedido = parMontopedido;
            tmpCobranza.Cantidadcuotas = parCantidadcuotas;
            tmpCobranza.NroDeCuotas = parNrodecuotas;
            tmpCobranza.Importecuota = parImportecuota;
            tmpCobranza.AmortizacionCuota = parAmortizacioncuota;
            tmpCobranza.InteresCuota = parInteresCuota;
            tmpCobranza.IvaCuota = parIvaCuota;
            tmpCobranza.AmortizacionVencer = parAmortizacionVencer;
            tmpCobranza.InteresesVencer = parInteresVencer;
            tmpCobranza.AporteCapital = parAporteCapital;
            tmpCobranza.Socio_id = parSocio_id;

            tmpCobranza.modificarCobranza();
        }

        public void GuardarCobranzaProvisoria(int parPrestamo_id, string parCedula, double parTasa, double parPorcentajeiva, double parMontopedido, int parCantidadcuotas, int parNrodecuotas, double parImportecuota, double parAmortizacioncuota, double parInteresCuota, double parIvaCuota, double parAmortizacionVencer, double parInteresVencer, int parSocio_id)
        {
            CobranzaProvisoria tmpCobranzaProvisoria = new CobranzaProvisoria();

            tmpCobranzaProvisoria.Prestamo_id = parPrestamo_id;
            tmpCobranzaProvisoria.Socio_nro = parCedula;
            tmpCobranzaProvisoria.Tasa = parTasa;
            tmpCobranzaProvisoria.Porcentajeiva = parPorcentajeiva;
            tmpCobranzaProvisoria.Monteopedido = parMontopedido;
            tmpCobranzaProvisoria.Cantidadcuotas = parCantidadcuotas;
            tmpCobranzaProvisoria.NroDeCuotas = parNrodecuotas;
            tmpCobranzaProvisoria.Importecuota = parImportecuota;
            tmpCobranzaProvisoria.AmortizacionCuota = parAmortizacioncuota;
            tmpCobranzaProvisoria.InteresCuota = parInteresCuota;
            tmpCobranzaProvisoria.IvaCuota = parIvaCuota;
            tmpCobranzaProvisoria.AmortizacionVencer = parAmortizacionVencer;
            tmpCobranzaProvisoria.InteresesVencer = parInteresVencer;
            tmpCobranzaProvisoria.Socio_id = parSocio_id;

            tmpCobranzaProvisoria.GuardarCobranzaProvisoria();
        }

        public void guardarCobranza(int parPrestamo_id, String parCedula, double parTasa, double parPorcentajeiva, double parMontopedido, int parCantidadcuotas, int parNrodecuotas, double parImportecuota, double parAmortizacioncuota, double parInteresCuota, double parIvaCuota, double parAmortizacionVencer, double parInteresVencer, double parAporteCapital, int parSocio_id)
        {
            Cobranza tmpCobranza = new Cobranza();

            tmpCobranza.Prestamo_id = parPrestamo_id;
            tmpCobranza.Socio_nro = parCedula;
            tmpCobranza.Tasa = parTasa;
            tmpCobranza.Porcentajeiva = parPorcentajeiva;
            tmpCobranza.Monteopedido = parMontopedido;
            tmpCobranza.Cantidadcuotas = parCantidadcuotas;
            tmpCobranza.NroDeCuotas = parNrodecuotas;
            tmpCobranza.Importecuota = parImportecuota;
            tmpCobranza.AmortizacionCuota = parAmortizacioncuota;
            tmpCobranza.InteresCuota = parInteresCuota;
            tmpCobranza.IvaCuota = parIvaCuota;
            tmpCobranza.AmortizacionVencer = parAmortizacionVencer;
            tmpCobranza.InteresesVencer = parInteresVencer;
            tmpCobranza.AporteCapital = parAporteCapital;
            tmpCobranza.Socio_id = parSocio_id;

            tmpCobranza.GuardarCobranza();
        }

        public void guardarCancelacion(int parNumeroPrestamo, int parCuotasPactadas, int parCuotasPagadas, double parTasa, double parMontoVale, double parImporteCuota, double parAmortizacionVencer, double parInteresesVencer, String parPresupuesto, String parSocioNumero, String parUsuario, DateTime FechaCancelacion, int socio_id)
        {
            Cancelacion tmpCancelacion = new Cancelacion();

            tmpCancelacion.Prestamo_id = parNumeroPrestamo;
            tmpCancelacion.Cuotaspactadas = parCuotasPactadas;
            tmpCancelacion.Cuotaspagadas = parCuotasPagadas;
            tmpCancelacion.Tasa = parTasa;
            tmpCancelacion.MontoVale = parMontoVale;
            tmpCancelacion.Importecuota = parImporteCuota;
            tmpCancelacion.AmortizacionVencer = parAmortizacionVencer;
            tmpCancelacion.InteresesVencer = parInteresesVencer;
            tmpCancelacion.Presupuesto = parPresupuesto;
            tmpCancelacion.Socio_nro = parSocioNumero;
            tmpCancelacion.Usuario = parUsuario;
            tmpCancelacion.FechaCancelacion = FechaCancelacion;
            tmpCancelacion.Socio_id = socio_id;

            tmpCancelacion.GuardarCancelacion();
        }

        public void cancelarCobranza(int idcobranza)
        {
            Cobranza tmpCobranza = new Cobranza();
            tmpCobranza.Cobranza_ID = idcobranza;
            tmpCobranza.cancelarCobranza();
        }

        public void GuardarFechaCierre(String Presupuesto, DateTime FechaDesde, DateTime HoraDesde, DateTime FechaHasta, DateTime HoraHasta, Double TotalImporte, Double AmortizacionAVencer, Double InteresesAVencer)
        {
            FechaCierre tmpFechaCierre = new FechaCierre();
            tmpFechaCierre.Presupuesto = Presupuesto;
            tmpFechaCierre.FechaDesde = FechaDesde;
            tmpFechaCierre.HoraDesde = HoraDesde;
            tmpFechaCierre.FechaHasta = FechaHasta;
            tmpFechaCierre.HoraHasta = HoraHasta;
            tmpFechaCierre.TotalImporte = TotalImporte;
            tmpFechaCierre.AmortizacionAVencer = AmortizacionAVencer;
            tmpFechaCierre.InteresesAVencer = InteresesAVencer;

            tmpFechaCierre.GuardarFechaCierre();
        }

        public void modificarParametrosCierreEmpresa(DateTime empresa_cierrePresupuestoAnterior, DateTime empresa_horaCierreAnterior, DateTime empresa_cierrePresupuestoActual, DateTime empresa_horacierreactual, DateTime empresa_vtoPresupuestoActual, String empresa_usuarioCierre)
        {
            Empresa tmpEmpresa = new Empresa();

            tmpEmpresa.Empresa_cierrePresupuestoAnterior = empresa_cierrePresupuestoAnterior;
            tmpEmpresa.Empresa_horaCierreAnterior = empresa_horaCierreAnterior;
            tmpEmpresa.Empresa_cierrePresupuestoActual = empresa_cierrePresupuestoActual;
            tmpEmpresa.Empresa_horacierreactual = empresa_horacierreactual;
            tmpEmpresa.Empresa_vtoPresupuestoActual = empresa_vtoPresupuestoActual;
            tmpEmpresa.Empresa_usuarioCierre = empresa_usuarioCierre;

            tmpEmpresa.modificarParametrosCierreEmpresa();
        }

        public DataSet devolverTotalesCobranzas()
        {
            Cobranza tmpCobranza = new Cobranza();
            DataSet totalesCobranza = tmpCobranza.devolverTotales();
            return totalesCobranza;
        }

        public DataSet devolverExcedidosSinPago(int id_socio)
        {
            Excedidos tmpExcedido = new Excedidos();
            DataSet tmpExcedidos = tmpExcedido.devolverExcedidosSinPago(id_socio);
            return tmpExcedidos;
        }

        public DataSet devolverExcedidosPorSocioIdyPresupuesto(int idSocio, string presupuesto)
        {
            Excedidos tmpExcedido = new Excedidos();
            DataSet tmpExcedidos2 = tmpExcedido.devolverExcedidosPorSocioIdyPresupuesto(idSocio, presupuesto);
            return tmpExcedidos2;
        }

        /*     public DataSet devolverExcedidosPorCI(string ci)
             {
                 Excedidos tmpExcedido = new Excedidos();
                 DataSet tmpExcedidos2 = tmpExcedido.devolverExcedidosPorCI(ci);
                 return tmpExcedidos2;
             }
       */
        public DataSet devolverHistoria(string ci, string presupuesto)
        {
            Historia tmpHistoria = new Historia();
            DataSet tmpHistorias = tmpHistoria.devolverHistoria(ci, presupuesto);
            return tmpHistorias;
        }

        public bool cierreEfectuado(String presupuesto)
        {
            FechaCierre tmpCierre = new FechaCierre();
            return tmpCierre.cierreEfectuado(presupuesto);
        }

        public void cierre()
        {
            double CuotaCapital;
            double amo_cuota;
            double amo_vencer;
            double int_vencer;
            int CuotasVan;
            double Wmora;
            double Wiva;
            double InteresCuota;
            double IvaCuota;

            double WIvaMora; //contiene el porcentaje

            // AGREGADOS POR NICO
            double tasa;
            int cantidadCuotas;
            double montoPedido;
            int id_cobranza;
            int id_prestamo;
            int socio_id;
            String cedula;
            double importeCuota;
            bool estaEnCobranza = false;
            DataSet dsCobranzasActualizadas;
            double aporteCapital;

            DateTime fechaVto = this.VtoPto(DateTime.Today);
            DateTime fechaCierre = DateTime.Today;
            DateTime horaCierre = DateTime.Now;
            DataSet dsParametros = DevolverEmpresa();
            DataSet dsSociosActivos = DevolverSociosActivos();
            DataSet dsFechasCierres = DevolverFechasCierres();
            DataSet dsCobranzasProvisorias = DevolverCobranzasProvisorias();


            CuotaCapital = Convert.ToDouble(dsParametros.Tables["empresas"].Rows[0][22].ToString());
            Wmora = Convert.ToDouble(dsParametros.Tables["empresas"].Rows[0][11].ToString());
            WIvaMora = Convert.ToDouble(dsParametros.Tables["empresas"].Rows[0][10].ToString());

            this.eliminarAmortizacionVencerCeroCobranza();

            DataSet dsCobranzas = DevolverCobranzas();

            if (dsCobranzas.Tables["cobranzas"].Rows.Count > 0)
            {
                for (int i = 0; i < dsCobranzas.Tables["cobranzas"].Rows.Count; i++)
                {
                    id_cobranza = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][0].ToString());
                    id_prestamo = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][1].ToString());
                    cedula = dsCobranzas.Tables["cobranzas"].Rows[i][2].ToString();
                    tasa = Convert.ToDouble(dsCobranzas.Tables["cobranzas"].Rows[i][3].ToString());
                    Wiva = Convert.ToDouble(dsCobranzas.Tables["cobranzas"].Rows[i][4].ToString()); // Porcentaje ivaç
                    montoPedido = Convert.ToDouble(dsCobranzas.Tables["cobranzas"].Rows[i][5].ToString());
                    CuotasVan = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][7].ToString()) + 1;
                    cantidadCuotas = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][6].ToString());
                    importeCuota = Convert.ToDouble(dsCobranzas.Tables["cobranzas"].Rows[i][8].ToString());
                    aporteCapital = Convert.ToDouble(dsCobranzas.Tables["cobranzas"].Rows[i][14].ToString());
                    socio_id = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][15].ToString());

                    amo_cuota = AmortCuota(tasa, CuotasVan, cantidadCuotas, montoPedido);

                    if (Wiva != 0)
                    {
                        InteresCuota = Convert.ToDouble(Strings.Format(((importeCuota - amo_cuota) / ((Wiva / 100) + 1)), "##,##0.00"));
                        IvaCuota = Convert.ToDouble(Strings.Format(importeCuota - amo_cuota - InteresCuota, "##,##0.00"));
                    }
                    else
                    {
                        InteresCuota = importeCuota - amo_cuota;
                        IvaCuota = 0;
                    }
                    amo_vencer = AmortVencer(tasa, cantidadCuotas, CuotasVan, importeCuota);
                    int_vencer = IntVencer(importeCuota, cantidadCuotas, CuotasVan, amo_vencer);

                    modificarCobranza(id_cobranza, id_prestamo, cedula, tasa, Wiva, montoPedido, cantidadCuotas, CuotasVan, importeCuota, amo_cuota, InteresCuota, IvaCuota, amo_vencer, int_vencer, aporteCapital, socio_id);
                }
            }
            //Incorporando los nuevos préstamos
            if (dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows.Count > 0)
            {
                for (int i = 0; i < dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows.Count; i++)
                {
                    int id_cobranzaProvisorio = Convert.ToInt32(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][0].ToString());
                    int id_prestamoProvisorio = Convert.ToInt32(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][1].ToString());
                    String cedulaProvisorio = Convert.ToString(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][2].ToString());
                    double tasaProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][3].ToString());
                    double WivaProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][4].ToString());
                    double montoPedidoProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][5].ToString());
                    int CuotasVanProvisorio = Convert.ToInt32(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][7].ToString());
                    int cantidadCuotasProvisorio = Convert.ToInt32(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][6].ToString());
                    double importeCuotaProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][8].ToString());
                    double amo_cuotaProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][9].ToString());
                    double InteresCuotaProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][10].ToString());
                    double IvaCuotaProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][11].ToString());
                    double amo_vencerProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][12].ToString());
                    double int_vencerProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][13].ToString());
                    double aporteCapitalProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][14].ToString());
                    int socio_idProvisorio = Convert.ToInt32(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][15].ToString());

                    for (int j = 0; !estaEnCobranza && j < dsCobranzas.Tables["cobranzas"].Rows.Count; j++)
                    {
                        if (Convert.ToInt32(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][15].ToString()) == Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[j][15].ToString()))
                        {
                            modificarCobranza(Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[j][0].ToString()), id_prestamoProvisorio, cedulaProvisorio, tasaProvisorio, WivaProvisorio, montoPedidoProvisorio, cantidadCuotasProvisorio, CuotasVanProvisorio, importeCuotaProvisorio, amo_cuotaProvisorio, InteresCuotaProvisorio, IvaCuotaProvisorio, amo_vencerProvisorio, int_vencerProvisorio, aporteCapitalProvisorio, socio_idProvisorio);
                            estaEnCobranza = true;
                        }
                    }

                    if (!estaEnCobranza)
                    {
                        guardarCobranza(id_prestamoProvisorio, cedulaProvisorio, tasaProvisorio, WivaProvisorio, montoPedidoProvisorio, cantidadCuotasProvisorio, CuotasVanProvisorio, importeCuotaProvisorio, amo_cuotaProvisorio, InteresCuotaProvisorio, IvaCuotaProvisorio, amo_vencerProvisorio, int_vencerProvisorio, aporteCapitalProvisorio, socio_idProvisorio);
                    }
                }
            }

            //agrego todos los socios tengan o no prestamos que no
            //hayan sido dados de baja
            estaEnCobranza = false;

            DataSet dsCobranzasIncorporarAporte = DevolverCobranzas();

            if (dsSociosActivos.Tables["socio"].Rows.Count > 0)
            {
                for (int i = 0; i < dsSociosActivos.Tables["socio"].Rows.Count; i++)
                {

                    for (int j = 0; !estaEnCobranza && j < dsCobranzasIncorporarAporte.Tables["cobranzas"].Rows.Count; j++)
                    {
                        if (dsSociosActivos.Tables["socio"].Rows[i][0].ToString() == dsCobranzasIncorporarAporte.Tables["cobranzas"].Rows[j][15].ToString())
                        {
                            agregarAporteCapitalCobranza(Convert.ToInt32(dsCobranzasIncorporarAporte.Tables["cobranzas"].Rows[j][0].ToString()), CuotaCapital);
                            estaEnCobranza = true;
                        }
                    }

                    if (!estaEnCobranza)
                    {
                        guardarCobranza(0, dsSociosActivos.Tables["socio"].Rows[i][3].ToString(), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, CuotaCapital, Convert.ToInt32(dsSociosActivos.Tables["socio"].Rows[i][0].ToString()));

                    }
                    estaEnCobranza = false;
                }
            }

            DateTime empresa_cierrePresupuestoAnterior = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][25].ToString()); // Cierre fecha presupuesto actual
            DateTime empresa_horaCierreAnterior = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][26].ToString()); // Cierre hora presupuesto actual
            DateTime empresa_cierrePresupuestoActual = fechaCierre;
            DateTime empresa_horacierreactual = horaCierre;
            DateTime empresa_vtoPresupuestoActual = fechaVto;
            String empresa_usuarioCierre = Utilidades.UsuarioLogueado.Alias;

            modificarParametrosCierreEmpresa(empresa_cierrePresupuestoAnterior, empresa_horaCierreAnterior, empresa_cierrePresupuestoActual, empresa_horacierreactual, empresa_vtoPresupuestoActual, empresa_usuarioCierre);

            //***************************************************
            // ACTUALIZO FECHAS CIERRES  ( HACER Sum(importecuota+aportecapital) )
            //***************************************************
            DateTime fecha_desde = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][26].ToString());
            DateTime hora_desde = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][27].ToString());
            String presupuesto_ = presupuesto();

            DataSet totalesCobranza = devolverTotalesCobranzas();

            Double totalImporteCobranzas = Convert.ToDouble(totalesCobranza.Tables["totalesCobranzas"].Rows[0][0].ToString());
            Double totalAmortizacionVencer = Convert.ToDouble(totalesCobranza.Tables["totalesCobranzas"].Rows[0][1].ToString());
            Double interesesVencer = Convert.ToDouble(totalesCobranza.Tables["totalesCobranzas"].Rows[0][2].ToString());

            GuardarFechaCierre(presupuesto_, fecha_desde, hora_desde, empresa_cierrePresupuestoActual, empresa_horacierreactual, totalImporteCobranzas, totalAmortizacionVencer, interesesVencer);

            // *************
            // ACTUALIZAR HISTORIA (Hasta acá anda)
            // *************

            dsCobranzasActualizadas = DevolverCobranzas();

            if (dsCobranzasActualizadas.Tables["cobranzas"].Rows.Count > 0)
            {
                for (int i = 0; i < dsCobranzasActualizadas.Tables["cobranzas"].Rows.Count; i++)
                {
                    // Por cada cobranza agrego un registro en el histórico                
                    String _Presupuesto = presupuesto_;
                    int _NumeroPrestamo = Convert.ToInt32(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][1].ToString()); //1
                    String _cedula = Convert.ToString(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][2].ToString()); //2
                    Double _tasa = Convert.ToDouble(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][3].ToString()); //3
                    Double _porcentajeiva = Convert.ToDouble(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][4].ToString()); //4
                    Double _montopedido = Convert.ToDouble(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][5].ToString()); //5
                    int _cantidadcuotas = Convert.ToInt32(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][6].ToString()); //6
                    int _nrodecuotas = Convert.ToInt32(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][7].ToString()); //7
                    Double _importecuota = Convert.ToDouble(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][8].ToString()); //8
                    Double _AmortizacionCuota = Convert.ToDouble(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][9].ToString()); //9
                    Double _InteresCuota = Convert.ToDouble(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][10].ToString()); //10
                    Double _IvaCuota = Convert.ToDouble(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][11].ToString()); //11
                    Double _AmortizacionVencer = Convert.ToDouble(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][12].ToString()); //12
                    Double _InteresVencer = Convert.ToDouble(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][13].ToString());//13
                    Double _aportecapital = Convert.ToDouble(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][14].ToString()); //14
                    int _socio_id = Convert.ToInt32(dsCobranzasActualizadas.Tables["cobranzas"].Rows[i][15].ToString());

                    string _numerocobro = "";
                    int _Inciso = 0;
                    int _oficina = 0;

                    Historia tmpHistoria = new Historia();
                    tmpHistoria._Presupuesto = _Presupuesto;
                    tmpHistoria._NumeroPrestamo = _NumeroPrestamo;
                    tmpHistoria._cedula = _cedula;
                    tmpHistoria._tasa = _tasa;
                    tmpHistoria._porcentajeiva = _porcentajeiva;
                    tmpHistoria._montopedido = _montopedido;
                    tmpHistoria._cantidadcuotas = _cantidadcuotas;
                    tmpHistoria._nrodecuotas = _nrodecuotas;
                    tmpHistoria._importecuota = _importecuota;
                    tmpHistoria._AmortizacionCuota = _AmortizacionCuota;
                    tmpHistoria._InteresCuota = _InteresCuota;
                    tmpHistoria._IvaCuota = _IvaCuota;
                    tmpHistoria._AmortizacionVencer = _AmortizacionVencer;
                    tmpHistoria._InteresVencer = _InteresVencer;
                    tmpHistoria._aportecapital = _aportecapital;
                    tmpHistoria._socio_id = _socio_id;

                    DataSet dsSocioID = devolverSocioId(_socio_id);

                    if (dsSocioID.Tables["socioPorId"].Rows.Count > 0)
                    {
                        _Inciso = Convert.ToInt32(dsSocioID.Tables["socioPorId"].Rows[0][12].ToString());
                        _oficina = Convert.ToInt32(dsSocioID.Tables["socioPorId"].Rows[0][11].ToString());
                        _numerocobro = dsSocioID.Tables["socioPorId"].Rows[0][4].ToString();
                    }

                    if (dsSocioID.Tables["socioPorId"].Rows.Count > 0)
                    {
                        tmpHistoria._numerocobro = _numerocobro;
                        tmpHistoria._Inciso = _Inciso;
                        tmpHistoria._oficina = _oficina;
                    }

                    //************************************
                    // En la misma recorrida del histórico actualizo los excedidos.
                    //*************************************
                    DataSet dsExcedidosSinPago = devolverExcedidosSinPago(_socio_id);

                    if (dsExcedidosSinPago.Tables["excedidosSinPago"].Rows.Count > 0)
                    {
                        int id_exedido = Convert.ToInt32(dsExcedidosSinPago.Tables["excedidosSinPago"].Rows[0][0].ToString());
                        double aRetener = Convert.ToDouble(dsExcedidosSinPago.Tables["excedidosSinPago"].Rows[0][3].ToString());
                        double retenido = Convert.ToDouble(dsExcedidosSinPago.Tables["excedidosSinPago"].Rows[0][4].ToString());
                        double aporteCapitalExcedido = Convert.ToDouble(dsExcedidosSinPago.Tables["excedidosSinPago"].Rows[0][8].ToString());
                        double _excedido = aRetener - retenido;
                        double moraExcedido = 0;
                        double ivaMoraExcedido = 0;

                        tmpHistoria._excedido = _excedido;

                        if ((aRetener - retenido) > aporteCapitalExcedido)
                        {
                            moraExcedido = Convert.ToDouble(Strings.Format(Pago_Mora(aRetener - retenido - aporteCapitalExcedido, _Presupuesto, Wmora, fechaVto.ToString("dd/MM/yyyy")), "###,###,##0.00"));

                            ivaMoraExcedido = Convert.ToDouble(Strings.Format(moraExcedido * (WIvaMora / 100), "###,###,##0.00"));
                        }
                        else
                        {
                            moraExcedido = 0;
                        }

                        if (dsExcedidosSinPago.Tables["excedidosSinPago"].Rows.Count > 0)
                        {
                            tmpHistoria._mora = moraExcedido;
                            if (moraExcedido != 0)
                            {
                                tmpHistoria._IvaMora = ivaMoraExcedido;
                            }
                        }

                        double importePagadoExcedido = (aRetener - retenido) + moraExcedido;

                        actualizarExcedidoCierre(id_exedido, DateTime.Today, importePagadoExcedido, presupuesto_);
                    }

                    tmpHistoria.Guardar();

                    // **************Vaciar la tabla cobranza privosoria*****************

                }

            }
            VaciarTablaCobranzaProvisoria();
        }
    }
}