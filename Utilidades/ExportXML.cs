using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Utilidades
{
    public class ExportXML
    {

        public void downloadXML(string path, Dictionary<string, string> documento, Dictionary<string, string> emisor, Dictionary<string, string> receptor, Dictionary<string, string> totales, Dictionary<string, string> items)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            // XmlDocument xml = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8\" standalone=\"yes", "");
            doc.AppendChild(docNode);

            string xml = @"<?xml version='1.0' encoding='UTF-8' ?>
                        <ns0:CFE_Adenda xmlns:ns0='http://cfe.dgi.gub.uy' xmlns:ds='http://www.w3.org/2000/09/xmldsig#' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xsi:schemaLocation='http://cfe.dgi.gub.uy CFEEmpresas_v1.8.xsd ' >
	                        <ns0:CFE version= '1.0' xmlns:ns0= 'http://cfe.dgi.gub.uy' >
                                <ns0:eTck>
			                        <ns0:TmstFirma></ns0:TmstFirma>
			                        <ns0:Encabezado>
				                        <ns0:IdDoc>
					                        <ns0:TipoCFE>101</ns0:TipoCFE>
					                        <ns0:Serie></ns0:Serie>
					                        <ns0:Nro></ns0:Nro>
					                        <ns0:FchEmis>" + documento["FchEmis"] + @"</ns0:FchEmis>
					                        <ns0:MntBruto>" + documento["MntBruto"] + @"</ns0:MntBruto>				
					                        <ns0:FmaPago>1</ns0:FmaPago>
				                        </ns0:IdDoc>
				                        <ns0:Emisor>
					                        <ns0:RUCEmisor>" + emisor["RUCEmisor"] + @"</ns0:RUCEmisor>
					                        <ns0:RznSoc>" + emisor["RznSoc"] + @"</ns0:RznSoc>
					                        <ns0:CdgDGISucur>" + emisor["CdgDGISucur"] + @"</ns0:CdgDGISucur>
					                        <ns0:DomFiscal>" + emisor["DomFiscal"] + @"</ns0:DomFiscal>
					                        <ns0:Ciudad>" + emisor["Ciudad"] + @"</ns0:Ciudad>
					                        <ns0:Departamento>" + emisor["Departamento"] + @"</ns0:Departamento>
				                        </ns0:Emisor>
				                        <ns0:Receptor>
					                        <ns0:TipoDocRecep>" + receptor["TipoDocRecep"] + @"</ns0:TipoDocRecep>
					                        <ns0:CodPaisRecep>" + receptor["CodPaisRecep"] + @"</ns0:CodPaisRecep>
					                        <ns0:DocRecep>" + receptor["DocRecep"] + @"</ns0:DocRecep>
					                        <ns0:RznSocRecep>" + receptor["RznSocRecep"] + @"</ns0:RznSocRecep>				
				                        </ns0:Receptor>			
				                        <ns0:Totales>
					                        <ns0:TpoMoneda>UYU</ns0:TpoMoneda>
					                        <ns0:MntNoGrv>" + totales["MntNoGrv"] + @"</ns0:MntNoGrv>				
					                        <ns0:MntNetoIvaTasaMin>" + totales["MntNetoIvaTasaMin"] + @"</ns0:MntNetoIvaTasaMin>
					                        <ns0:MntNetoIVATasaBasica>" + totales["MntNetoIVATasaBasica"] + @"</ns0:MntNetoIVATasaBasica>
					                        <ns0:IVATasaMin>" + totales["IVATasaMin"] + @"</ns0:IVATasaMin>
					                        <ns0:IVATasaBasica>" + totales["IVATasaBasica"] + @"</ns0:IVATasaBasica>
					                        <ns0:MntIVATasaMin>" + totales["MntIVATasaMin"] + @"</ns0:MntIVATasaMin>
					                        <ns0:MntIVATasaBasica>" + totales["MntIVATasaBasica"] + @"</ns0:MntIVATasaBasica>
					                        <ns0:MntTotal>" + totales["MntTotal"] + @"</ns0:MntTotal>
					                        <ns0:CantLinDet>" + totales["CantLinDet"] + @"</ns0:CantLinDet>
					                        <ns0:MntPagar>" + totales["MntPagar"] + @"</ns0:MntPagar>
				                        </ns0:Totales>
			                        </ns0:Encabezado>
			                        <ns0:Detalle>
				                        <ns0:Item>
					                        <ns0:NroLinDet>1</ns0:NroLinDet>
					                        <ns0:IndFact>3</ns0:IndFact>
					                        <ns0:NomItem>Interes cuota</ns0:NomItem>
					                        <ns0:Cantidad>1</ns0:Cantidad>
					                        <ns0:UniMed>N/A</ns0:UniMed>
					                        <ns0:PrecioUnitario>" + items["PrecioUnitario1"] + @"</ns0:PrecioUnitario>
					                        <ns0:MontoItem>" + items["PrecioUnitario1"] + @"</ns0:MontoItem>
				                        </ns0:Item>
                                        <ns0:Item>
					                        <ns0:NroLinDet>2</ns0:NroLinDet>
					                        <ns0:IndFact>3</ns0:IndFact>
					                        <ns0:NomItem>Mora</ns0:NomItem>
					                        <ns0:Cantidad>1</ns0:Cantidad>
					                        <ns0:UniMed>N/A</ns0:UniMed>
					                        <ns0:PrecioUnitario>" + items["PrecioUnitario2"] + @"</ns0:PrecioUnitario>
					                        <ns0:MontoItem>" + items["PrecioUnitario2"] + @"</ns0:MontoItem>
				                        </ns0:Item>                             			   				   				   				                        
			                        </ns0:Detalle>
                                    <ns0:CAEData>
				                        <ns0:CAE_ID></ns0:CAE_ID>
				                        <ns0:DNro></ns0:DNro>
				                        <ns0:HNro></ns0:HNro>
				                        <ns0:FecVenc></ns0:FecVenc>
			                        </ns0:CAEData>
		                        </ns0:eTck>
	                        </ns0:CFE>	
	                        <ns0:Adenda>
		                        <Rondanet>
			                        <A01>
				                        <NumerarPDV>1</NumerarPDV>
				                        <FirmarPDV>1</FirmarPDV>				
			                        </A01>
		                        </Rondanet>
	                        </ns0:Adenda>	
                        </ns0:CFE_Adenda>";

            File.WriteAllText(path, xml);
        }
    }
}
