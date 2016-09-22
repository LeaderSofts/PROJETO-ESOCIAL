<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<%@page import="java.sql.SQLException"%>
<%@page import="java.util.List"%>
<%@page import="java.util.ArrayList"%>
<%@page import="java.sql.ResultSet"%>
<%@page import="java.sql.PreparedStatement"%>
<%@page import="java.sql.Connection"%>
<%@page import="java.sql.DriverManager"%>    
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@taglib prefix="sql" uri="http://java.sun.com/jsp/jstl/sql" %>    
    
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
	<title>Insert title here</title>
	<link rel="shortcut icon" href="favicon.ico">
	<link type="text/css" rel="stylesheet"  href="bootstrap.css"/>
	<link type="text/css" rel="stylesheet"  href="bootstrap.min.css"/>
</head>
<body>
	
	<script type="text/javascript" src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/dataTables.bootstrap.min.js"></script>
    <script src="https://www.atlasestateagents.co.uk/javascript/tether.min.js"></script><!-- Tether for Bootstrap --> 
    <script src="https://cdn.rawgit.com/twbs/bootstrap/v4-dev/dist/js/bootstrap.min.js"></script><!-- Bootstrap --> 
    <script type="text/javascript" src="bootstrap.js"></script>
    <script type="text/javascript" src="bootstrap.min.js"></script>
    
	
	<!-- CÓDIGO JAVA QUE FAZ A CONEXÃO COM A BASE DE DADOS E QUERY-->
	    <%
      	 //http://tomcat.apache.org/
         int id=0;
         String val="";
         String user="sa";
         String pass="foxplan";
         String dbase="FoxplanTeste";
         String driver="com.microsoft.sqlserver.jdbc.SQLServerDriver";
         String url="jdbc:sqlserver://localhost:1433;user="+user+";password="+pass+";databaseName="+dbase+";";
         String sql="SELECT dbo.PPESSOA.Codigo [COD_PESSOA], dbo.PPESSOA.NOME AS [NOME], dbo.PPESSOA.REGPROFISSIONAL [REGPREV] FROM PPESSOA, PFUNC WHERE PPESSOA.CODIGO = PFUNC.CODPESSOA";
         //String sqlMunicipios="SELECT * FROM TESTEEST";
         Class.forName(driver);
         Connection con = DriverManager.getConnection(url);
         PreparedStatement pstmt = con.prepareStatement(sql);
         ResultSet reset = pstmt.executeQuery();
         int i = 0;
         if(reset.next() ){
            val=reset.getString("NOME");
            id=reset.getInt("COD_PESSOA");
         }
         String a=val;
         int b=id;
        %>
        <!-- CÓDIGO JAVA QUE SETA O VALOR NA INPUT_TEXT -->        
          <%
            String chapa="";
            String tipoRegPrev="";
            String tipoRegTrab="";
            String tipoTrabalhador="";
            String nome="";
            String dtNascto="";
            String corRaca="";
            String nacionalidade="";
            String estadoNatal="";
            String naturalidade="";
            String sexo="";
            String estadoCivil="";
            String escolaridade="";
            String nomeMae="";
            String nomePai="";
            String defiFisico="";
            String defiAuditivo="";
            String defiFala="";
            String defiVisual="";
            String defiMental="";
            String defiIntelectual="";
            String defiReabilitada="";
            String cpf="";
            String rg="";
            String ufRg="";
            String oeRg="";
            String dtEmiRg="";
            String titEleitor="";
            String zonaEleitoral="";
            String dtTituloEleitoral="";
            String secaoTituloEleitoral="";
            String ufTitulo="";
            String ctps="";
            String serieCtps="";
            String dtEmiCtps="";
            String ufCtps="";
            String nit="";
            
            String cnh="";
            String dtVencCnh="";
            String oeCnh="";
            String dtEmiCnh="";
            String categCnh="";
            String ufCnh="";
            String dtPrimeiraCnh="";
            String pisPasep="";
            String bancoPis="";
            String certiReserv="";
            String dtEmiCertiReserv="";
            String situMilitar="";
            String numeroRegIdCivil="";
            String oeRic="";
            String dtEmiRic="";
            String passaporte="";
            String regNacioEstrangeiro="";
            String dtEmiRNE="";
            String oeRNE="";
            String bancoPgtoRNE="";
            String agenciaPgtoRNE="";
            String contaPgtoRNE="";
            String tipoContaPgtoRNE="";
            String bancoPgtoFGTS="";
            String tipLograResidBras="";
            String lograResidBras="x";
            String numeroLograResidBras="x";
            String compleLograResidBras="x";
            String tipoBairroResidBras="x";
            String bairroResidBras="x";
            String estadoResidBras="x";
            String cidadeResidBras="x";
            String cepResidBras="x";
            String paisNasctoResidBras="x";
            String paisResidBras="x";
            String descriLograResidBras="x";
            String numLograResidBras="x";
            //String compleLograResidBras="";
            //String bairroLograResidBras="";
            
            String sqlView = "SELECT * FROM View1";
            
            pstmt = con.prepareStatement(sqlView);
            reset = pstmt.executeQuery();
            int cont=0;
            ResultSet rs=reset;
            try{
                if(rs.next() ){
                    cont+=1;
                    while(rs.next() ){
                        cont++;
                    }
                }
            }catch(SQLException sqlexc){
                sqlexc.fillInStackTrace();
                javax.swing.JOptionPane.showMessageDialog(null,"ResultSet fail at TRY-CATCH-FINALLY BLOCK: " /*+lista.size()*/ );
            }finally{
                //javax.swing.JOptionPane.showMessageDialog(null," O tamanho da lista é: " + cont );
                rs.close();
            }
            
        try{
            pstmt = con.prepareStatement(sqlView);
            reset = pstmt.executeQuery();
            if( reset.next() ){
                chapa=reset.getString("CHAPA");
                tipoRegPrev=reset.getString("TPREGIMEPREV");
                //String tipoRegtrab=reset.getString("TPREGTRAB");
                tipoTrabalhador=reset.getString("CODTIPO");
                nome=reset.getString("NOME");
                dtNascto=reset.getString("DATANASCIMENTO");
                corRaca=reset.getString("CORRACA");
                nacionalidade=reset.getString("NACIONALIDADE");
                estadoNatal=reset.getString("ESTADONATAL");
                naturalidade=reset.getString("NATURALIDADE");
                corRaca=reset.getString("CORRACA");
                nacionalidade=reset.getString("NACIONALIDADE");
                estadoNatal=reset.getString("ESTADONATAL");
                //naturalidade=reset.getString("NATURALIDADE");
                sexo=reset.getString("SEXO");
                estadoCivil=reset.getString("ESTADOCIVIL");
                escolaridade=reset.getString("GRAUINSTRUCAO");
                nomeMae=reset.getString("NOMEMAE");
                nomePai=reset.getString("NOMEPAI");
                defiFisico=reset.getString("DEFICIENTEFISICO");
                defiAuditivo=reset.getString("DEFICIENTEAUDITIVO");
                defiFala=reset.getString("DEFICIENTEFALA");
                defiVisual=reset.getString("DEFICIENTEVISUAL");
                defiMental=reset.getString("DEFICIENTEMENTAL");
                defiIntelectual=reset.getString("DEFICIENTEINTELECTUAL");
                defiReabilitada=reset.getString("DEFICIENCIAREABILITADA");
                cpf=reset.getString("CPF");
                rg=reset.getString("CARTIDENTIDADE");
                ufRg=reset.getString("UFCARTIDENT");
                oeRg=reset.getString("ORGEMISSORIDENT");
                dtEmiRg=reset.getString("DTEMISSAOIDENT");
                titEleitor=reset.getString("TITULOELEITOR");
                zonaEleitoral=reset.getString("ZONATITELEITOR"); 
                dtTituloEleitoral= reset.getString("DTTITELEITOR");
                secaoTituloEleitoral=reset.getString("TITULOELEITOR"); // REVER...
                ufTitulo= reset.getString("ESTELEIT");
                ctps=reset.getString("CARTEIRATRAB");;  //CARTEIRATRAB
                serieCtps=reset.getString("SERIECARTTRAB");; //SERIECARTTRAB
                dtEmiCtps=reset.getString("DTCARTTRAB");
                ufCtps=reset.getString("UFCARTTRAB");
                nit=reset.getString("NIT");
                
                cnh=reset.getString("CARTMOTORISTA");
                dtVencCnh=reset.getString("DTVENCHABILIT");
                oeCnh=reset.getString("ORGEMISSORCNH");
                dtEmiCnh=reset.getString("DTEMISSAOCNH");
                categCnh=reset.getString("TIPOCARTHABILIT");
                ufCnh=reset.getString("UFCNH");
                dtPrimeiraCnh=reset.getString("DATAPRIMEIRACNH");
                pisPasep=reset.getString("PISPASEP");
                bancoPis=reset.getString("CODBANCOPIS");
                certiReserv=reset.getString("CERTIFRESERV");
                dtEmiCertiReserv=reset.getString("DTEMICERTRESERV");
                situMilitar=reset.getString("SITMILITAR");
                numeroRegIdCivil=reset.getString("NUMERORIC");
                oeRic=reset.getString("ORGEMISSORRIC");
                dtEmiRic=reset.getString("DTEMISSAORIC");
                passaporte=reset.getString("NPASSAPORTE");
                regNacioEstrangeiro=reset.getString("NROREGGERAL");
                dtEmiRNE=reset.getString("DTEMISSAORNE");
                oeRNE=reset.getString("ORGEMISSORRNE");
                
                bancoPgtoRNE=reset.getString("CODBANCOPAGTO"); 
                agenciaPgtoRNE=reset.getString("CODAGENCIAPAGTO"); 
                contaPgtoRNE=reset.getString("CONTAPAGAMENTO");
                tipoContaPgtoRNE=reset.getString("TPCONTAANCARIA");
                bancoPgtoFGTS=reset.getString("CODBANCOFGTS");
                tipLograResidBras=reset.getString("CODTIPORUA");
                lograResidBras=reset.getString("RUA");
                numeroLograResidBras=reset.getString("NUMERO");
                compleLograResidBras=reset.getString("COMPLEMENTO");
                tipoBairroResidBras=reset.getString("CODTIPOBAIRRO");
                bairroResidBras=reset.getString("BAIRRO");
                estadoResidBras=reset.getString("ESTADO");
                cidadeResidBras=reset.getString("CIDADE");
                cepResidBras=reset.getString("CEP");
                //paisNasctoResidBras=reset.getString("PAIS");
                paisResidBras=reset.getString("IDPAIS");
                descriLograResidBras=reset.getString("LOGRADOURO");
                numLograResidBras=reset.getString("NUMERO");
                
                //CONTINUAR AQUI
                //------------------------------------------------
                System.out.println(chapa);
                //System.out.println(tipoRegPrev);
                System.out.println(tipoRegTrab);
                System.out.println(tipoTrabalhador);
                System.out.println(nome);
                System.out.println(dtNascto);
                System.out.println(corRaca);
                System.out.println(nacionalidade);
                System.out.println(estadoNatal);
                System.out.println(naturalidade);
                System.out.println(sexo);
                System.out.println(estadoCivil);
                System.out.println(escolaridade);
                System.out.println(nomeMae);
                System.out.println(nomePai);
                System.out.println(defiFisico);
                System.out.println(defiAuditivo);
                System.out.println(defiFala);
                System.out.println(defiVisual);
                System.out.println(defiMental);
                System.out.println(defiIntelectual);
                System.out.println(defiReabilitada);
                System.out.println(cpf);
                System.out.println(rg);
                System.out.println(ufRg);
                System.out.println(oeRg);
                System.out.println(dtEmiRg);
                System.out.println(titEleitor);
                System.out.println(zonaEleitoral);
                System.out.println(dtTituloEleitoral);
                System.out.println(secaoTituloEleitoral);
                System.out.println(ufTitulo);
                System.out.println(ctps);
                System.out.println(serieCtps);
                System.out.println(dtEmiCtps);
                System.out.println(ufCtps);
                System.out.println(nit);
            }else{
                //javax.swing.JOptionPane.showMessageDialog(null, "No more rows!");
            }
        }catch(SQLException sqlexc){
            sqlexc.fillInStackTrace();
        }finally{
            //javax.swing.JOptionPane.showMessageDialog(null," O tamanho da lista é: " + cont );
        }
          %>
          
          <%
              //SELECT PARA RETORNAR MUNICÍPIOS
              String sqlMun = "SELECT * FROM CidIbge";
              PreparedStatement pstmt1 = con.prepareStatement(sqlMun);
              ResultSet rs1=pstmt1.executeQuery();
              int codCitSize=0;
            try{
                if( rs1.next() ){
                    codCitSize+=1;
                    while(rs1.next() ){
                        //codMunic = rs1.getString("CODMUNIC");
                        //municipio = rs1.getString("NOMEMUNIC");
                        codCitSize+=1;
                    }
                }
            }catch(SQLException sqlexc){
            sqlexc.fillInStackTrace();
        }finally{
            rs1.close();
        }  
          %>
          
        <%
            String sqlviewPaisMunicipio="SELECT CASE WHEN VIEW1.CIDADE IN (SELECT CODMUNIC FROM CidIbge ) THEN VIEW1.CIDADE ELSE 'ERROR' END CIDADE,CASE WHEN VIEW1.PAIS IN (SELECT IDPAIS FROM paises ) THEN VIEW1.PAIS ELSE 'ERROR' END PAIS FROM VIEW1";
            PreparedStatement pstmt2=con.prepareStatement(sqlviewPaisMunicipio);
            ResultSet rs2=pstmt2.executeQuery();
            try{
                if( rs2.next() ){
                    naturalidade=reset.getString("CIDADE");
                    paisNasctoResidBras=reset.getString("PAIS");
                    System.out.println("Naturalidade: " + naturalidade);
                    System.out.println("País: " +paisNasctoResidBras);
                    while(rs2.next() ){
                        naturalidade=reset.getString("NATURALIDADE");
                        paisNasctoResidBras=reset.getString("PAIS");
                        System.out.println("Naturalidade: " + naturalidade);
                        System.out.println("País: " +paisNasctoResidBras);
                    }
                }
            }catch(SQLException sqlexc){
                sqlexc.fillInStackTrace();
            }finally{
                rs2.close();
            }
          %>
          
          
          
          
        <h1>Admissão de Trabalhador</h1>
        <form name="form1" method="post" action="trabalhadores.jsp">
            
            <p> <label id="lblMatri" > MATRÍCULA: </label>
               <input type="text" id="txtMatri" name="txtMatri" size="40" maxlength="40" value="<% out.println(chapa); %>">
            </p>
            
            <p> <label id="lblRegPrev" > TIPO DE REGIME PREVIDENCIÁRIO: </label>
               <input type="text" id="txtRegPrev" name="txtRegPrev" size="40" maxlength="40" value="<% out.println(tipoRegPrev); %>">
            </p>
            
            <p> <label id="lblRegTrab" > TIPO DE REGIME TRABALHISTA: </label>
               <input type="text" id="txtRegTrab" name="txtRegTrab" size="40" maxlength="40" value="<% out.println(tipoRegTrab); %>">
            </p>
            
            <p> <label id="lblTipoTrab" > TIPO DE TRABALHADOR: </label>
               <input type="text" id="txtTipoTrab" name="txtTipoTrab" size="40" maxlength="40" value="<% out.println(tipoTrabalhador); %>">
            </p>
            
            <p> <label id="lblNome" > NOME: </label>
               <input type="text" id="txtNome" name="txtNome" size="40" maxlength="40" value="<% out.println(nome); %>">
            </p>
            
            <p> <label id="lblDtnascto" > DATA DE NASCIMENTO: </label>
               <input type="text" id="txtDtnascto" name="txtDtnascto" size="40" maxlength="40" value="<% out.println(dtNascto); %>">
            </p>
            
            <p> <label id="lblDtnascto" > COR/RAÇA: </label>
               <input type="text" id="txtCorRaca" name="txtCorRaca" size="40" maxlength="40" value="<% out.println(corRaca); %>">
            </p>
            
            <p> <label id="lblDtnascto" > NACIONALIDADE: </label>
               <input type="text" id="txtNacionalidade" name="txtNacionalidade" size="40" maxlength="40" value="<% out.println(nacionalidade); %>">
            </p>
            
            <p> <label id="lblDtnascto" > ESTADO NATAL: </label>
               <input type="text" id="txtEstadoNatal" name="txtEstadoNatal" size="40" maxlength="40" value="<% out.println(estadoNatal); %>">
            </p>
            
            <p> <label id="lblDtnascto" > DATA NASCIMENTO: </label>
               <input type="text" id="txtDtNascto" name="txtDtNascto" size="40" maxlength="40" value="<% out.println(naturalidade); %>">
            </p>
            
            <p> <label id="lblCpf" > NATURALIDADE: </label>
               <input type="text" id="txtCpf" name="txtCpf" size="40" maxlength="40" value="<% out.println(cpf); %>">
            </p>                       
            
            <p> <input type="hidden" id="querySizeTx" name="querySizeTx" size="9" maxlength="9" value="<% out.println(cont); %>"> </p>
            <input type="hidden" id="sizeListMunTx" name="sizeListMunTx" size="9" maxlength="9" value="<% out.println(codCitSize); %>">
            <p> &nbsp; </p>
            
        </form>
	


	<div>
		<table cellspacing="0px"  cellpadding ="0px" border="1" width="100%" id="tabela1">
			<thead>
				<tr>
					<th> CHAPA  </th>
                <th> REG. PREVIDENCIÁRIO </th>
                <th> TIPO TRABALHADOR </th>
                <th> NOME </th>
                <th> DT NASCIMENTO </th>
                <th> COR/RAÇA </th>
                <th> NACIONALIDADE </th>
                <th> ESTADO NATAL </th>
                <th> NATURALIDADE </th>
                <th> SEXO </th>
                <th> ESTADO CIVIL </th>
                <th> ESCOLARIDADE </th>
                <th> NOME DA MÃE </th>
                <th> NOME DO PAI </th>
                <th> DEF. FÍSICO </th>
                <th> DEF. AUDITIVO </th>
                <th> DEF. FALA </th>
                <th> DEF. VISUAL </th>
                <th> DEF. MENTAL </th>
                <th> DEF. INTELECTUAL </th>
                <th> DEF. REABILITADA </th>
                <th> CPF </th>
                <th> CARTIDENTIDADE </th>
                <th> UF RG </th>
                <th> ORGÃO EMI.RG </th>
                <th> DT EMISSÃO RG </th>
                <th> TÍTULO ELEITO </th>
                <th> ZONA TÍTULO ELEITOR </th>
                <th> DT TÍTULO ELEITOR </th>
                <th> SEÇÃO TÍTULO ELEITOR </th>
                <th> TÍTULO ELEITOR </th>
                <th> CART. TRABALHO </th>
                <th> SÉRIE CART. TRABALHO </th>
                <th> DT EMI. CTPS </th>
                <th> UF CTPS </th>
                <th> NIT </th>
                <th> CNH </th>
                <th> DT VENCTO CNH</th>
                <th> ÓRGÃO EMISS. CNH</th>
                <th> DT EMISSÃO CNH</th>
                <th> CATEGORIA CNH </th>
                <th> UF CNH </th>
                <th> DT PRIMEIRA CNH</th>
                <th> PIS/PASEP</th>
                <th> BANCO PIS </th>
                <th> CERTIF. RESERVISTA</th>
                <th> DT EMI. CERTIF. RESERV.</th>
                <th> SITUAÇÃO MILITAR </th>
                <th> REGISTRO DE IDEN. CIVIL </th>
                <th> ÓRGÃO EMISS. RIC </th>
                <th> DT EMISS. RIC </th>
                <th> PASSAPORTE </th>
                <th> REGISTRO NACIO. ESTRANGEIRO</th>
                <th> DT EMISS. RNE</th>
                <th> ÓRGÃO EMISS. RNE</th>
                <th> BANCO P/ PAGAMENTO </th>
                <th> AGÊNCIA PAGTO </th>
                <th> CONTA </th>
                <th> TIPO DE CONTA </th>
                <th> BANCO PGTO FGTS </th>
                <th> TIPO LOGRADOURO </th>
                <th> LOGRADOURO </th>
                <th> NÚMERO </th>
                <th> COMPLEMENTO </th>
                <th> TIPO BAIRRO </th>
                <th> BAIRRO </th>
                <th> ESTADO </th>
                <th> CIDADE </th>
                <th> CEP </th>
                <th> PAÍS </th>
                <!--<th> PAÍS RESID. </th>-->
           <!-- <th> DESCRI. LOGRA. </th>
                <th> NÚMERO. LOGRA. </th>
                <th> COMPLEMENTO </th>
                <th> BAIRRO </th>
                <th> CIDADE </th>
                <th> CEP </th>
                <th> DT CHEGADA </th>
                <th> CLASS. ESTRANGEIRO </th>-->
                <th> CASADO C/ BRASILEIRO </th>
                <th> FILHOS BRASILEIROS </th>
                <th> TELEFONE </th>
                <th> CELULAR </th>
                <th> TEL. CONTATO</th>
                <th> EMAIL </th>
                <th> FUNÇÃO </th>
                <th> CÓD. FUNÇÃO </th>
                <th> DT. ADMISSÃO </th>
                <th> SALÁRIO </th>
                <th> JORNADA </th>
                <th> SINDICATO </th>
                <th> CÓD. SINDICATO </th>
                <th> CNPJ SINDICATO </th>
                <th> DT. BASE </th>
                <th> HORÁRIO TRABALHO </th>
                <th> COD. HOR. TRAB. </th>
                <th> ÍNDICE HOR. TRAB.</th>
                <th> TIPO REGIME JORNADA </th>
                <th> INDICATIVO ADMISSÃO </th>
                <th> NATUREZA ATIVIDADE </th>
                <th> TIPO ADMISSÃO </th>
                <th> CÓD. TIPO ADMISSÃO </th>
                <th> MOTIVO ADMISSÃO </th>
                <th> CÓD. MOTIVO ADMISSÃO </th>
                <th> SITUAÇÃO FGTS </th>
                <th> CÓD. SITUAÇÃO FGTS</th>
                <th> DT. OPÇÃO FGTS </th>
                <th> SITUAÇÃO RAIS </th>
                <th> CÓD. SITU. RAIS </th>
                <th> VÍNCULO RAIS </th>
                <th> CÓD. VÍNCULO RAIS </th>
                <th> CONTRIBUIÇÃO SINDICAL </th>
                <th> CÓD. CONTRIB. SINDICAL </th>
                <th> NÚMERO REGISTRO ÓRGÃO DE CLASSE OC </th>
                <th> ÓRGÃO EMISSOR OC </th>
                <th> DT EMISSÃO OC </th>
                <th> DT VALIDADE OC </th>
                <th> </th>
                
                <sql:setDataSource driver="com.microsoft.sqlserver.jdbc.SQLServerDriver" user="sa" password="foxplan" url="jdbc:sqlserver://localhost:1433;databaseName=FoxplanTeste" 
                var="conn"/>
                <sql:query var="query" dataSource="${conn}">
                    SELECT * FROM View1
                </sql:query>            
                                
                    <c:forEach items="${query.rows}" var="item" varStatus="id">  
                    <tr>
                    <th> <input type="text" id="txchapa${id.count}" name="txchapa${id.count}" size="13" maxlength="15" style="background-color: #ffffff" value="${item.chapa}"> </th>
                    <th> <input type="text" id="txregprev${id.count}" name="txregprev${id.count}" size="13" maxlength="15" value="${item.TPREGIMEPREV}"> </th>
                    <th> <input type="text" id="txtptrabalhador${id.count}" name="txtptrabalhador${id.count}" size="13" maxlength="15" value="${item.TPREGIMEPREV}"> </th>
                    <th> <input type="text" id="txnome${id.count}" name="txnome${id.count}" size="35" maxlength="55" value="${item.nome}"> </th>
                    <th> <input type="text" id="txdtnascto${id.count}" name="txdtnascto${id.count}" size="15" maxlength="3" value="${item.DATANASCIMENTO}"> </th>
                    <th> <input type="text" id="txcorraca${id.count}" name="txcorraca${id.count}" size="15" maxlength="13" value="${item.CORRACA}"> </th>
                    <th> <input type="text" id="txnacionalidade${id.count}" name="txnacionalidade${id.count}" size="13" maxlength="55" value="${item.NACIONALIDADE}"> </th>
                    <th> <input type="text" id="txestadonatal${id.count}" name="txestadonatal${id.count}" size="10" maxlength="55" value="${item.ESTADONATAL}"> </th>
                    <th> <input type="text" id="txnaturalidade${id.count}" name="txnaturalidade${id.count}" size="20" maxlength="55" value="${item.CIDADE}"> </th>
                    <th> <input type="text" id="txsexo${id.count}" name="txsexo${id.count}" size="9" maxlength="2" value="${item.SEXO}"> </th>
                    <th> <input type="text" id="txestadocivil${id.count}" name="txestadocivil${id.count}" size="13" maxlength="20" value="${item.ESTADOCIVIL}"> </th>
                    <th> <input type="text" id="txescolaridade${id.count}" name="txescolaridade${id.count}" size="13" maxlength="20" value="${item.GRAUINSTRUCAO}"> </th>
                    <th> <input type="text" id="txnomemae${id.count}" name="txnomemae${id.count}" size="40" maxlength="20" value="${item.NOMEMAE}"> </th>
                    <th> <input type="text" id="txnomepai${id.count}" name="txnomepai${id.count}" size="40" maxlength="20" value="${item.NOMEPAI}"> </th>
                    <th> <input type="text" id="txdeficifis${id.count}" name="txdeficifis${id.count}" size="9" maxlength="20" value="${item.DEFICIENTEFISICO}"> </th>
                    <th> <input type="text" id="txdeficiaud${id.count}" name="txdeficiaud${id.count}" size="11" maxlength="20" value="${item.DEFICIENTEAUDITIVO}"> </th>
                    <th> <input type="text" id="txdeficifala${id.count}" name="txdeficifala${id.count}" size="9" maxlength="20" value="${item.DEFICIENTEFALA}"> </th>
                    <th> <input type="text" id="txdeficivisu${id.count}" name="txdeficivisu${id.count}" size="9" maxlength="20" value="${item.DEFICIENTEVISUAL}"> </th>
                    <th> <input type="text" id="txdeficimental${id.count}" name="txdeficimental${id.count}" size="9" maxlength="20" value="${item.DEFICIENTEMENTAL}"> </th>
                    <th> <input type="text" id="txdeficintelectual${id.count}" name="txdeficintelectual${id.count}" size="13" maxlength="20" value="${item.DEFICIENTEINTELECTUAL}"> </th>
                    <th> <input type="text" id="txdeficireabil${id.count}" name="txdeficireabil${id.count}" size="13" maxlength="20" value="${item.DEFICIENCIAREABILITADA}"> </th>
                    <th> <input type="text" id="txcpf${id.count}" name="txcpf${id.count}" size="11" maxlength="13" value="${item.CPF}"> </th>
                    <th> <input type="text" id="txrg${id.count}" name="txrg${id.count}" size="13" maxlength="55" value="${item.CARTIDENTIDADE}"> </th>
                    <th> <input type="text" id="txufrg${id.count}" name="txufrg${id.count}" size="9" maxlength="20" value="${item.UFCARTIDENT}"> </th>
                    <th> <input type="text" id="txorgaoemirg${id.count}" name="txorgaoemirg${id.count}" size="13" maxlength="20" value="${item.ORGEMISSORIDENT}"> </th>
                    <th> <input type="text" id="txdtemirg${id.count}" name="txdtemirg${id.count}" size="16" maxlength="25" value="${item.DTEMISSAOIDENT}"> </th>
                    <th> <input type="text" id="txtituloeleit${id.count}" name="txtituloeleit${id.count}" size="15" maxlength="20" value="${item.TITULOELEITOR}"> </th>
                    <th> <input type="text" id="txzonaeleit${id.count}" name="txzonaeleit${id.count}" size="9" maxlength="20" value="${item.ZONATITELEITOR}"> </th>
                    <th> <input type="text" id="txdttituloeleit${id.count}" name="txdttituloeleit${id.count}" size="17" maxlength="25" value="${item.DTTITELEITOR}"> </th>
                    <th> <input type="text" id="txsecaotituloeleit${id.count}" name="txsecaotituloeleit${id.count}" size="15" maxlength="20" value="${item.TITULOELEITOR}"> </th>
                    <th> <input type="text" id="txuftituloeleit${id.count}" name="txuftituloeleit${id.count}" size="15" maxlength="20" value="${item.ESTELEIT}"> </th>
                    <th> <input type="text" id="txctps${id.count}" name="txctps${id.count}" size="15" maxlength="55" value="${item.CARTEIRATRAB}"> </th>
                    <th> <input type="text" id="txseriectps${id.count}" name="txseriectps${id.count}" size="15" maxlength="55" value="${item.SERIECARTTRAB}"> </th>
                    <th> <input type="text" id="txdtemictps${id.count}" name="txdtemictps${id.count}" size="17" maxlength="25" value="${item.DTCARTTRAB}"> </th>
                    <th> <input type="text" id="txufctps${id.count}" name="txufctps${id.count}" size="9" maxlength="20" value="${item.UFCARTTRAB}"> </th>
                    <th> <input type="text" id="txnit${id.count}" name="txnit${id.count}" size="15" maxlength="20" value="${item.NIT}"> </th>
                    <th> <input type="text" id="txcnh${id.count}" name="txcnh${id.count}" size="15" maxlength="20" value="${item.CARTMOTORISTA}"> </th>
                    <th> <input type="text" id="txdatavctocnh${id.count}" name="txdatavctocnh${id.count}" size="17" maxlength="25" value="${item.DTVENCHABILIT}"> </th>
                    <th> <input type="text" id="txorgemicnh${id.count}" name="txorgemicnh${id.count}" size="13" maxlength="20" value="${item.ORGEMISSORCNH}"> </th>
                    <th> <input type="text" id="txdataemicnh${id.count}" name="txdataemicnh${id.count}" size="17" maxlength="25" value="${item.DTEMISSAOCNH}"> </th>
                    <th> <input type="text" id="txcategoriacnh${id.count}" name="txcategoriacnh${id.count}" size="9" maxlength="20" value="${item.TIPOCARTHABILIT}"> </th>
                    <th> <input type="text" id="txufcnh${id.count}" name="txufcnh${id.count}" size="9" maxlength="10" value="${item.UFCNH}"> </th>
                    <th> <input type="text" id="txdtprimeiracnh${id.count}" name="txdtprimeiracnh${id.count}" size="17" maxlength="25" value="${item.DATAPRIMEIRACNH}"> </th>
                    <th> <input type="text" id="txpispasep${id.count}" name="txpispasep${id.count}" size="15" maxlength="25" value="${item.PISPASEP}"> </th>
                    <th> <input type="text" id="txbancopis${id.count}" name="txbancopis${id.count}" size="15" maxlength="25" value="${item.CODBANCOPIS}"> </th>
                    <th> <input type="text" id="txcertreservista${id.count}" name="txcertreservista${id.count}" size="20" maxlength="25" value="${item.CERTIFRESERV}"> </th>
                    <th> <input type="text" id="txdtemicertreservista${id.count}" name="txdtemicertreservista${id.count}" size="20" maxlength="25" value="${item.DTEMICERTRESERV}"> </th>
                    <th> <input type="text" id="txsitumilitar${id.count}" name="txsitumilitar${id.count}" size="20" maxlength="25" value="${item.SITMILITAR}"> </th>
                    <th> <input type="text" id="txnumeroric${id.count}" name="txnumeroric${id.count}" size="20" maxlength="25" value="${item.NUMERORIC}"> </th>
                    <th> <input type="text" id="txorgaoemiric${id.count}" name="txorgaoemiric${id.count}" size="20" maxlength="25" value="${item.ORGEMISSORRIC}"> </th>
                    <th> <input type="text" id="txdtemiric${id.count}" name="txdtemiric${id.count}" size="20" maxlength="25" value="${item.DTEMISSAORIC}"> </th>
                    <th> <input type="text" id="txpassaporte${id.count}" name="txpassaporte${id.count}" size="20" maxlength="25" value="${item.NPASSAPORTE}"> </th>
                    <th> <input type="text" id="txrne${id.count}" name="txrne${id.count}" size="20" maxlength="25" value="${item.NROREGGERAL}"> </th>
                    <th> <input type="text" id="txdtemirne${id.count}" name="txdtemirne${id.count}" size="20" maxlength="25" value="${item.DTEMISSAORNE}"> </th>
                    <th> <input type="text" id="txorgaoemirne${id.count}" name="txorgaoemirne${id.count}" size="20" maxlength="25" value="${item.ORGEMISSORRNE}"> </th>
                    <th> <input type="text" id="txbancopgto${id.count}" name="txbancopgto${id.count}" size="20" maxlength="25" value="${item.CODBANCOPAGTO}"> </th>
                    <th> <input type="text" id="txagenciapgto${id.count}" name="txagenciapgto${id.count}" size="20" maxlength="25" value="${item.CODAGENCIAPAGTO}"> </th>
                    <th> <input type="text" id="txconta${id.count}" name="txconta${id.count}" size="20" maxlength="25" value="${item.CONTAPAGAMENTO}"> </th>
                    <th> <input type="text" id="txtipoconta${id.count}" name="txtipoconta${id.count}" size="20" maxlength="25" value="${item.TPCONTAANCARIA}"> </th>
                    <th> <input type="text" id="txbancopgtofgts${id.count}" name="txbancopgtofgts${id.count}" size="20" maxlength="25" value="${item.CODBANCOFGTS}"> </th>
                    
                    <th> <input type="text" id="txtipolograd${id.count}" name="txtipolograd${id.count}" size="20" maxlength="25" value="${item.CODTIPORUA}"> </th>
                    <th> <input type="text" id="txlograrua${id.count}" name="txlograrua${id.count}" size="37" maxlength="55" value="${item.RUA}"> </th>
                    <th> <input type="text" id="txlogranumero${id.count}" name="txlogranumero${id.count}" size="20" maxlength="25" value="${item.NUMERO}"> </th>
                    <th> <input type="text" id="txlogracomplem${id.count}" name="txlogracomplem${id.count}" size="20" maxlength="25" value="${item.COMPLEMENTO}"> </th>
                    <th> <input type="text" id="txtipobairro${id.count}" name="txtipobairro${id.count}" size="20" maxlength="25" value="${item.CODTIPOBAIRRO}"> </th>
                    <th> <input type="text" id="txbairro${id.count}" name="txbairro${id.count}" size="25" maxlength="55" value="${item.BAIRRO}"> </th>
                    <th> <input type="text" id="txestadoibge${id.count}" name="txestadoibge${id.count}" size="20" maxlength="25" value="${item.ESTADO}"> </th>
                    <th> <input type="text" id="txcidadeibge${id.count}" name="txcidadeibge${id.count}" size="30" maxlength="55" value="${item.CIDADE}"> </th>
                    <th> <input type="text" id="txcepibge${id.count}" name="txcepibge${id.count}" size="20" maxlength="25" value="${item.CEP}"> </th>
                    <th> <input type="text" id="txpaisibge${id.count}" name="txpaisibge${id.count}" size="25" maxlength="25" value="${item.PAIS}"> </th>
                    <!--<th> <input type="text" id="txpaisresidibge${id.count}" name="txpaisresidibge${id.count}" size="25" maxlength="35" value="${item.IDPAIS}"> </th>-->
                    <!--<th> <input type="text" id="txdesclogra${id.count}" name="txdesclogra${id.count}" size="35" maxlength="55" value="${item.IDPAIS}"> </th>
                    <th> <input type="text" id="txnumlograibge${id.count}" name="txnumlograibge${id.count}" size="35" maxlength="55" value="${item.LOGRADOURO}"> </th>
                    <th> <input type="text" id="txcomplemibge${id.count}" name="txcomplemibge${id.count}" size="35" maxlength="55" value="${item.CODTIPORUA}"> </th>
                    <th> <input type="text" id="txbairroibge${id.count}" name="txbairroibge${id.count}" size="35" maxlength="55" value="${item.CODTIPORUA}"> </th>
                    <th> <input type="text" id="txnomecidadeibge${id.count}" name="txnomecidadeibge${id.count}" size="35" maxlength="55" value="${item.CODTIPORUA}"> </th>
                    <th> <input type="text" id="txcodpostalibge${id.count}" name="txcodpostalibge${id.count}" size="35" maxlength="55" value="${item.CODTIPORUA}"> </th>
                    <th> <input type="text" id="txdtchegadaestrang${id.count}" name="txdtchegadaestrang${id.count}" size="35" maxlength="55" value="${item.CODTIPORUA}"> </th>
                    <th> <input type="text" id="txclassificestrang${id.count}" name="txclassificestrang${id.count}" size="35" maxlength="55" value="${item.CODTIPORUA}"> </th>-->
                    <th> <input type="text" id="txcasadocombrasileiro${id.count}" name="txcasadocombrasileiro${id.count}" size="35" maxlength="55" value="${item.CONJUGEBRASIL}"> </th>
                    <th> <input type="text" id="txfilhosbrasileiros${id.count}" name="txfilhosbrasileiros${id.count}" size="25" maxlength="55" value="${item.FILHOSBRASIL}"> </th>
                    <th> <input type="text" id="txtelefone${id.count}" name="txtelefone${id.count}" size="15" maxlength="20" value="${item.TELEFONE1}"> </th>
                    <th> <input type="text" id="txcelular${id.count}" name="txcelular${id.count}" size="15" maxlength="20" value="${item.TELEFONE2}"> </th>
                    <th> <input type="text" id="txtelcontato${id.count}" name="txtelcontato${id.count}" size="15" maxlength="20" value="${item.TELEFONE3}"> </th>
                    <th> <input type="text" id="txemail${id.count}" name="txemail${id.count}" size="30" maxlength="40" value="${item.EMAIL}"> </th>
                    <th> <input type="text" id="txfuncao${id.count}" name="txfuncao${id.count}" size="35" maxlength="55" value="${item.FUNCAO}"> </th>
                    <th> <input type="text" id="txcodfuncao${id.count}" name="txcodfuncao${id.count}" size="15" maxlength="25" value="${item.CODFUNCAO}"> </th>
                    
                    <th> <input type="text" id="txdataadmissao${id.count}" name="txdataadmissao${id.count}" size="25" maxlength="40" value="${item.DATAADMISSAO}"> </th>
                    <th> <input type="text" id="txsalario${id.count}" name="txsalario${id.count}" size="15" maxlength="25" value="${item.SALARIO}"> </th>
                    <th> <input type="text" id="txjornada${id.count}" name="txjornada${id.count}" size="25" maxlength="35" value="${item.JORNADAMENSAL}"> </th>
                    <th> <input type="text" id="txsindicato${id.count}" name="txsindicato${id.count}" size="25" maxlength="55" value="${item.SINDICATO}"> </th>
                    <th> <input type="text" id="txcodsindicato${id.count}" name="txcodsindicato${id.count}" size="15" maxlength="35" value="${item.CODSINDICATO}"> </th>
                    <th> <input type="text" id="txcnpjsindicato${id.count}" name="txcnpj${id.count}" size="25" maxlength="35" value="${item.CNPJ}"> </th>
                    <th> <input type="text" id="txdtvalor${id.count}" name="txdtvalor${id.count}" size="25" maxlength="35" value="${item.DTVALOR}"> </th>
                    <th> <input type="text" id="txhorariotrab${id.count}" name="txhorariotrab${id.count}" size="25" maxlength="35" value="${item.DESCRICAO}"> </th>
                    <th> <input type="text" id="txcodhorariotrab${id.count}" name="txcodhorariotrab${id.count}" size="25" maxlength="35" value="${item.CODHORARIO}"> </th>
                    <th> <input type="text" id="txindicehorariotrab${id.count}" name="txindicehorariotrab${id.count}" size="15" maxlength="35" value="${item.INDINICIOHOR}"> </th>

                    <th> <input type="text" id="txtipregimjornadtrab${id.count}" name="txtipregimjornadtrab${id.count}" size="15" maxlength="25" value="${item.TPREGIMEJORNADA}"> </th>
                    <th> <input type="text" id="txindicativoadmissao${id.count}" name="txindicativoadmissao${id.count}" size="15" maxlength="25" value="${item.INDADMISSÃO}"> </th>
                    <th> <input type="text" id="txnaturezaatividade${id.count}" name="txnaturezaatividade${id.count}" size="15" maxlength="25" value="${item.NATUREZAATIVIDADE}"> </th>
                    <th> <input type="text" id="txtipoadmissao${id.count}" name="txtipoadmissao${id.count}" size="15" maxlength="25" value="${item.TIPOADM}"> </th>
                    <th> <input type="text" id="txcodtipoadmissao${id.count}" name="txcodtipoadmissao${id.count}" size="15" maxlength="25" value="${item.TIPOADMISSAO}"> </th>
                    
                    <th> <input type="text" id="txmotivoadmissao${id.count}" name="txmotivoadmissao${id.count}" size="25" maxlength="55" value="${item.MOTADM}"> </th>
                    <th> <input type="text" id="txcodmotivoadmissao${id.count}" name="txcodmotivoadmissao${id.count}" size="15" maxlength="25" value="${item.CODMOTIVOADM}"> </th>
                    <th> <input type="text" id="txsitufgts${id.count}" name="txsitufgts${id.count}" size="25" maxlength="55" value="${item.SITUACAOFGTS}"> </th>
                    <th> <input type="text" id="txcodsitufgts${id.count}" name="txcodsitufgts${id.count}" size="15" maxlength="25" value="${item.SITUACAOFGTS}"> </th>
                    <th> <input type="text" id="txdtopcaofgts${id.count}" name="txdtopcaofgts${id.count}" size="15" maxlength="25" value="${item.DTOPCAOFGTS}"> </th>
                    <th> <input type="text" id="txsiturais${id.count}" name="txsiturais${id.count}" size="15" maxlength="25" value="${item.SITUACAORAIS}"> </th>
                    <th> <input type="text" id="txcodsiturais${id.count}" name="txcodsiturais${id.count}" size="15" maxlength="25" value="${item.SITUACAORAIS}"> </th>
                    <th> <input type="text" id="txvinculorais${id.count}" name="txvinculorais${id.count}" size="25" maxlength="35" value="${item.VINCULORAIS}"> </th>
                    <th> <input type="text" id="txcodvinculorais${id.count}" name="txcodvinculorais${id.count}" size="15" maxlength="35" value="${item.VINCULORAIS}"> </th>
                    <th> <input type="text" id="txcontribsindical${id.count}" name="txcontribsindical${id.count}" size="15" maxlength="35" value="${item.VLRSINDICATO}"> </th>
                    <th> <input type="text" id="txcodcontribsindical${id.count}" name="txcodcontribsindical${id.count}" size="15" maxlength="35" value="${item.CONTRIBSINDICAL}"> </th>
                    <th> <input type="text" id="txnumeroregorgclasseoc${id.count}" name="txnumeroregorgclasseoc${id.count}" size="15" maxlength="25" value="${item.NUMEROREGISTRO}"> </th>
                    <th> <input type="text" id="txorgaoemissoroc${id.count}" name="txorgaoemissoroc${id.count}" size="25" maxlength="35" value="${item.CODORGAOCLASSE}"> </th>
                    <th> <input type="text" id="txdtemissoc${id.count}" name="txdtemissoc${id.count}" size="25" maxlength="35" value="${item.DATAEMISSAO}"> </th>
                    <th> <input type="text" id="txdtvalidadeoc${id.count}" name="txdtvalidadeoc${id.count}" size="25" maxlength="35" value="${item.DATAVALIDADE}"> </th>
                    
                    </tr>        
                </c:forEach>
            </thead>
				
						
		</table>
		
	</div>
	
	<script src="http://code.jquery.com/jquery-1.10.2.min.js"></script>
        <script> $(document).ready(function () {
        });
              
        var sizeQuery=document.getElementById('querySizeTx').value;
        var sizeList=document.getElementById('sizeListMunTx').value;
        var sizeQueryCont=parseInt(sizeQuery);
        var sizeListCont=parseInt(sizeList);
                            
        function validaCampo(){
            
            for( var it = 1; it <= sizeQueryCont; it++){
    
                var vtxChapa=document.getElementById('txchapa'+it).value;       
                var vtxNome=document.getElementById('txnome'+it).value;         
                var vtxTpTrab=document.getElementById('txtptrabalhador'+it).value;
                var vtxTpRegPrev=document.getElementById('txregprev'+it).value; 
                var vtxDtNascto=document.getElementById('txdtnascto'+it).value; 
                var vtxCorRaca=document.getElementById('txcorraca'+it).value;   
                var vtxNacionalidade=document.getElementById('txnacionalidade'+it).value;
                var vtxEstadoNatal=document.getElementById('txestadonatal'+it).value;
                var vtxNaturalidade=document.getElementById('txnaturalidade'+it).value;
                var vtxSexo=document.getElementById('txsexo'+it).value;
                var vtxEstadoCivil=document.getElementById('txestadocivil'+it).value;
                var vtxEscolaridade=document.getElementById('txescolaridade'+it).value;
                var vtxNomeMae=document.getElementById('txnomemae'+it).value;
                var vtxNomePai=document.getElementById('txnomepai'+it).value;
                var vtxDeficiFis=document.getElementById('txdeficifis'+it).value;
                var vtxDeficiAud=document.getElementById('txdeficiaud'+it).value;
                var vtxDeficiFala=document.getElementById('txdeficifala'+it).value;
                var vtxDeficiVisual=document.getElementById('txdeficivisu'+it).value;
                var vtxDeficiMental=document.getElementById('txdeficimental'+it).value;
                var vtxDeficiIntelectual=document.getElementById('txdeficintelectual'+it).value;
                var vtxDeficiReabilit=document.getElementById('txdeficireabil'+it).value;
                var vtxCpf=document.getElementById('txcpf'+it).value;
                var vtxRg=document.getElementById('txrg'+it).value;
                var vtxUfRg=document.getElementById('txufrg'+it).value;
                var vtxOrgaoEmiRg=document.getElementById('txorgaoemirg'+it).value;
                var vtxDtEmiRg=document.getElementById('txdtemirg'+it).value;
                var vtxTitEleit=document.getElementById('txtituloeleit'+it).value;
                var vtxZonaTit=document.getElementById('txzonaeleit'+it).value;
                var vtxDtTit=document.getElementById('txdttituloeleit'+it).value;
                var vtxSecaoTit=document.getElementById('txsecaotituloeleit'+it).value;
                var vtxUfTit=document.getElementById('txuftituloeleit'+it).value;
                var vtxCtps =document.getElementById('txctps'+it).value;
                var vtxSerieCtps =document.getElementById('txseriectps'+it).value;
                var vtxDtEmiCtps =document.getElementById('txdtemictps'+it).value;
                var vtxUfCtps =document.getElementById('txufctps'+it).value;      
                var vtxNit =document.getElementById('txnit'+it).value;            
                var vtxCnh =document.getElementById('txcnh'+it).value;            
                var vtxDataVctoCnh =document.getElementById('txdatavctocnh'+it).value;
                var vtxOrgaEmiCnh =document.getElementById('txorgemicnh'+it).value;
                var vtxDtEmiCnh =document.getElementById('txdataemicnh'+it).value;
                var vtxDtEmiCnh =document.getElementById('txdataemicnh'+it).value;
                var vtxCategCnh =document.getElementById('txcategoriacnh'+it).value;
                var vtxUfCnh =document.getElementById('txufcnh'+it).value;
                var vtxDtPrimeiraCnh =document.getElementById('txdtprimeiracnh'+it).value;
                var vtxPisPasep =document.getElementById('txpispasep'+it).value;
                var vtxBancoPis =document.getElementById('txbancopis'+it).value;
                var vtxCertireserv =document.getElementById('txcertreservista'+it).value;
                var vtxDtEmiCertireserv =document.getElementById('txdtemicertreservista'+it).value;
                var vtxSituMilit =document.getElementById('txsitumilitar'+it).value;
                var vtxNumRic =document.getElementById('txnumeroric'+it).value;
                var vtxOrgaoEmiRic =document.getElementById('txorgaoemiric'+it).value;
                var vtxDtEmiRic =document.getElementById('txdtemiric'+it).value;
                var vtxPassaporte =document.getElementById('txpassaporte'+it).value;
                var vtxRNE=document.getElementById('txrne'+it).value;
                var vtxDtEmiRNE=document.getElementById('txdtemirne'+it).value;
                var vtxOrgaoEmiRNE=document.getElementById('txorgaoemirne'+it).value;
                var vtxBancoPagto=document.getElementById('txbancopgto'+it).value;
                var vtxAgenciaPagto=document.getElementById('txagenciapgto'+it).value;
                var vtxConta=document.getElementById('txconta'+it).value;
                var vtxTpConta=document.getElementById('txtipoconta'+it).value;
                var vtxBancoFgts=document.getElementById('txbancopgtofgts'+it).value;
                var vtxTipoLogra=document.getElementById('txtipolograd'+it).value;
                var vtxLograRua=document.getElementById('txlograrua'+it).value;
                var vtxLograNum=document.getElementById('txlogranumero'+it).value;
                var vtxLograComple=document.getElementById('txlogracomplem'+it).value;
                var vtxTipoBairro=document.getElementById('txtipobairro'+it).value;
                var vtxBairro=document.getElementById('txbairro'+it).value;
                var vtxEstadoIbge=document.getElementById('txestadoibge'+it).value;
                var vtxCidadeIbge=document.getElementById('txcidadeibge'+it).value;
                var vtxCepIbge=document.getElementById('txcepibge'+it).value;
                var vtxPaisIbge=document.getElementById('txpaisibge'+it).value;
                //var vtxPaisResidIbge=document.getElementById('txpaisresidibge'+it).value;
                //var vtxDescriLograIbge=document.getElementById(''+it).value; //???????????
                //var vtxNumLograIbge=document.getElementById('txnumlograibge'+it).value;
               /* var vtxCompleIbge=document.getElementById('"txcomplemibge'+it).value;
                var vtxNumLograIbge=document.getElementById('txnumlograibge'+it).value;
                var vtxBairroIbge=document.getElementById('txbairroibge'+it).value;
                var vtxNomeCidIbge=document.getElementById('txnomecidadeibge'+it).value;
                var vtxCodPostalIbge=document.getElementById('txcodpostalibge'+it).value;
                var vtxDtChegEstran=document.getElementById('txdtchegadaestrang'+it).value;
                var vtxClassifiEstrang=document.getElementById('txclassificestrang'+it).value;
               */ var vtxCasadoComBrasileiro=document.getElementById('txcasadocombrasileiro'+it).value;
                var vtxFilhosBrasileiros=document.getElementById('txfilhosbrasileiros'+it).value;
                var vtxTelefone=document.getElementById('txtelefone'+it).value;
                var vxtCelular=document.getElementById('txcelular'+it).value;
                var vtxTelContato=document.getElementById('txtelcontato'+it).value;
                var vtxEmail=document.getElementById('txemail'+it).value;
                var vtxFuncao=document.getElementById('txfuncao'+it).value;
                var vtxCodFuncao=document.getElementById('txcodfuncao'+it).value; /**/
                var vtxDtAdmissao=document.getElementById('txdataadmissao'+it).value;
                var vtxSalario=document.getElementById('txsalario'+it).value;
                var vtxJornada=document.getElementById('txjornada'+it).value;
                var vtxSindicato=document.getElementById('txsindicato'+it).value;
                var vtxCodSindicato=document.getElementById('txcodsindicato'+it).value;
                var vtxCnpjSindic=document.getElementById('txcnpjsindicato'+it).value;
                
                var vtxDataValor=document.getElementById('txdtvalor'+it).value;
                var vtxHorarioTrab=document.getElementById('txhorariotrab'+it).value;
                var vtxCodHorarioTrab=document.getElementById('txcodhorariotrab'+it).value;
                var vtxIndiceHorarioTrab=document.getElementById('txindicehorariotrab'+it).value;
                
                var vtxTpRegimeJornada=document.getElementById('txtipregimjornadtrab'+it).value;
                var vtxIndicativoAdmissao=document.getElementById('txindicativoadmissao'+it).value;
                var vtxNaturezaAtividade=document.getElementById('txnaturezaatividade'+it).value;
                var vtxTipoAdmissao=document.getElementById('txtipoadmissao'+it).value;
                var vtxCodTipoAdmissao=document.getElementById('txcodtipoadmissao'+it).value;
                var vtxMotivoAdmissao=document.getElementById('txmotivoadmissao'+it).value;
                var vtxCodMotivoAdmissao=document.getElementById('txcodmotivoadmissao'+it).value;
                //var vtxCodTipoAdmissao=document.getElementById('txcodtipoadmissao'+it).value;
                var vtxSituacaoFgts=document.getElementById('txsitufgts'+it).value;
                var vtxCodSituacaoFgts=document.getElementById('txcodsitufgts'+it).value;
                var vtxDtOpcaoFgts=document.getElementById('txdtopcaofgts'+it).value;
//                var vtxMotivoAdmissao=document.getElementById('txmotivoadmissao'+it).value;
//                var vtxCodMotivoAdmissao=document.getElementById('txcodmotivoadmissao'+it).value;
//                var vtxSituacaoFgts=document.getElementById('txsitufgts'+it).value;
//                var vtxCodSituacaoFgts=document.getElementById('txcodsitufgts'+it).value;
//                var vtxDtOpcaoFgts=document.getElementById('txdtopcaofgts'+it).value;
                var vtxSituacaoRais=document.getElementById('txsiturais'+it).value;
                var vtxCodSituacaoRais=document.getElementById('txcodsiturais'+it).value;
                var vtxVinculoRais=document.getElementById('txvinculorais'+it).value;
                var vtxCodVinculoRais=document.getElementById('txcodvinculorais'+it).value;
                var vtxContribSindical=document.getElementById('txcontribsindical'+it).value;
                var vtxCodContribSindical=document.getElementById('txcodcontribsindical'+it).value;
                var vtxNumeroRegClassOc=document.getElementById('txnumeroregorgclasseoc'+it).value;
                var vtxOrgemssoroc=document.getElementById('txorgaoemissoroc'+it).value;
                var vtxDtEmissOc=document.getElementById('txdtemissoc'+it).value;
                var vtxDtValidOc=document.getElementById('txdtvalidadeoc'+it).value;

                //=================================////=================================////=================================//            
            if( vtxChapa ==="" || vtxChapa === undefined ){
                document.getElementById('txchapa'+it).value="#Erro!";
                document.getElementById('txchapa'+it).style.backgroundColor="#ff0000";
            }
            if( vtxChapa.substring(0,7).trim() === "eSocial" ){
                document.getElementById('txchapa'+it).value="#Erro!";
                document.getElementById('txchapa'+it).style.backgroundColor="#ff0000";
            }                    
            //=================================//
            
            if(vtxTpRegPrev==="" || vtxTpRegPrev===undefined ){
                document.getElementById('txregprev'+it).value="#Erro!";
                document.getElementById('txregprev'+it).style.backgroundColor="#ff0000";
            }
            if(vtxTpRegPrev !== '1' && vtxTpRegPrev !== '2' && vtxTpRegPrev !== '3'){
                document.getElementById('txregprev'+it).value="#Erro!";
                document.getElementById('txregprev'+it).style.backgroundColor="#ff0000";
            }
            //=================================//            
            if(vtxTpTrab === "" || vtxTpTrab===undefined ){
                document.getElementById('txtptrabalhador'+it).value="#Erro!";
                document.getElementById('txtptrabalhador'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxNome === "" || vtxNome===undefined){
                document.getElementById('txnome'+it).value="#Erro!";
                document.getElementById('txnome'+it).style.backgroundColor="#ff0000";
            }
            
            now = new Date();
            var dt = parseInt(vtxDtNascto.substring(6,11));
            //var dt1= parseInt(new Date());
            var ano = now.getFullYear();
            var dtValida= ano-dt;
            
            if(vtxDtNascto === '' || vtxDtNascto===undefined){
                document.getElementById('txdtnascto'+it).value="#Erro!";
                document.getElementById('txdtnascto'+it).style.backgroundColor="#ff0000";
            }
            if(vtxDtNascto !== '' && vtxDtNascto !== undefined){
                if(dtValida < 15) {
                        document.getElementById('txdtnascto'+it).value="#Erro!";
                        document.getElementById('txdtnascto'+it).style.backgroundColor="#ff0000";
                }
            }
            //=================================//
            if(vtxCorRaca=== '' || vtxCorRaca===undefined){
                document.getElementById('txcorraca'+it).value="#Erro!";
                document.getElementById('txcorraca'+it).style.backgroundColor="#ff0000";
            }
            if(vtxCorRaca.trim() !== '1' && vtxCorRaca.trim() !== '2' && vtxCorRaca.trim() !== '3'
             && vtxCorRaca.trim() !== '4' && vtxCorRaca.trim() !== '5' && vtxCorRaca.trim() !== '6'){
                document.getElementById('txcorraca'+it).value="#Erro!";
                document.getElementById('txcorraca'+it).style.backgroundColor="#ff0000";
            }
            //=================================//            
            if(vtxNacionalidade === "" || vtxNacionalidade ===undefined){
                document.getElementById('txnacionalidade'+it).value="#Erro!";
                document.getElementById('txnacionalidade'+it).style.backgroundColor="red";
            }
            var jsTmpVerNacionalidade=document.getElementById('vtxNacionalidade');
            
            if( veriPaisNacionalidade(vtxNacionalidade) === false ){
                document.getElementById('txnacionalidade'+it).value="#Erro!";
                document.getElementById('txnacionalidade'+it).style.backgroundColor="red";
            }    
            //=================================//
            var validaUF=false;
            var tmpUf=document.getElementById('txestadonatal'+it).value;
            if(vtxEstadoNatal==='' || vtxEstadoNatal===undefined ){
                document.getElementById('txestadonatal'+it).value="#Erro!";
                document.getElementById('txestadonatal'+it).style.backgroundColor="#ff0000";
            }
            if( validarCampoUF(tmpUf.trim() ) === true ){
                validaUF=true;
            }else{
                document.getElementById('txnacionalidade'+it).value="#Erro!";
                document.getElementById('txnacionalidade'+it).style.backgroundColor="red";
            }           
            //=================================//
            
            if(vtxNaturalidade==='' || vtxNaturalidade===undefined){
                //validarErros('txnaturalidade'+it);
                document.getElementById('txnaturalidade'+it).value="#Erro!";
                document.getElementById('txnaturalidade'+it).style.backgroundColor="red";
            }
             if( vtxNaturalidade!=='' && vtxNaturalidade!==undefined ){
                    if( vtxNaturalidade==='ERROR' || vtxNaturalidade==='ERROR'){
                        document.getElementById('txnaturalidade'+it).style.backgroundColor="red";
                    }
            }
            //=================================//
            if( vtxSexo==='' || vtxSexo===undefined ){
                document.getElementById('txsexo'+it).value="#Erro!";
                document.getElementById('txsexo'+it).style.backgroundColor="red";
            }
            if( vtxSexo.toUpperCase().trim() !== 'M' && vtxSexo.toUpperCase().trim() !== 'F' ){
                document.getElementById('txsexo'+it).value="#Erro!";
                document.getElementById('txsexo'+it).style.backgroundColor="red";
            }
            
            //=================================//
            if( vtxEstadoCivil ==='' || vtxEstadoCivil ===undefined ){
                document.getElementById('txestadocivil'+it).value="#Erro!";
                document.getElementById('txestadocivil'+it).style.backgroundColor="#ff0000";
            }
            if( vtxEstadoCivil.trim() !=='1' && vtxEstadoCivil.trim() !=='2' && vtxEstadoCivil.trim() !=='3' 
              && vtxEstadoCivil.trim() !=='4' && vtxEstadoCivil.trim() !=='5'){
               document.getElementById('txestadocivil'+it).value="#Erro!";
               document.getElementById('txestadocivil'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if( vtxEscolaridade ==='' || vtxEscolaridade ===undefined ){
                document.getElementById('txescolaridade'+it).value="#Erro!";
                document.getElementById('txestadocivil'+it).style.backgroundColor="#ff0000";
            }
             if( vtxEscolaridade.trim() !=='1' && vtxEscolaridade.trim() !=='2' && vtxEscolaridade.trim() !=='3' 
            && vtxEscolaridade.trim() !=='4'&& vtxEscolaridade.trim() !=='5' && vtxEscolaridade.trim() !=='6'
            && vtxEscolaridade.trim() !=='7' && vtxEscolaridade.trim() !=='8' && vtxEscolaridade.trim() !=='9'
            && vtxEscolaridade.trim() !=='10' && vtxEscolaridade.trim() !=='11' && vtxEscolaridade.trim() !=='12'){    
                document.getElementById('txescolaridade'+it).value="#Erro!";
                document.getElementById('txescolaridade'+it).style.backgroundColor="#ff0000";
            } 
            //=================================//
            if( vtxNomeMae ==='' || vtxNomeMae ===undefined ){
                document.getElementById('txnomemae'+it).value="#Erro!";
                document.getElementById('txnomemae'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if( vtxNomePai ==='' || vtxNomePai ===undefined ){
                document.getElementById('txnomepai'+it).value="#Erro!";
                document.getElementById('txnomepai'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if( vtxDeficiFis ==='' || vtxDeficiFis ===undefined ){
                document.getElementById('txdeficifis'+it).value="#Erro!";
                document.getElementById('txdeficifis'+it).style.backgroundColor="#ff0000";
            }
            if( vtxDeficiFis.toUpperCase().trim() !== 'S' && vtxDeficiFis.toUpperCase().trim() !== 'N' ){
                document.getElementById('txdeficifis'+it).value="#Erro!";
                document.getElementById('txdeficifis'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if( vtxDeficiAud ==='' || vtxDeficiAud ===undefined ){
                document.getElementById('txdeficiaud'+it).value="#Erro!";
                document.getElementById('txdeficiaud'+it).style.backgroundColor="#ff0000";
            }
            if( vtxDeficiAud.toUpperCase().trim() !== 'S' && vtxDeficiAud.toUpperCase().trim() !== 'N' ){
                document.getElementById('txdeficiaud'+it).value="#Erro!";
                document.getElementById('txdeficiaud'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if( vtxDeficiFala ==='' || vtxDeficiFala ===undefined ){
                document.getElementById('txdeficifala'+it).value="#Erro!";
                document.getElementById('txdeficifala'+it).style.backgroundColor="#ff0000";
            }
            if( vtxDeficiFala.toUpperCase().trim() !== 'S' && vtxDeficiFala.toUpperCase().trim() !== 'N' ){
                document.getElementById('txdeficifala'+it).value="#Erro!";
                document.getElementById('txdeficifala'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if( vtxDeficiVisual ==='' || vtxDeficiVisual ===undefined ){
                document.getElementById('txdeficivisu'+it).value="#Erro!";
                document.getElementById('txdeficivisu'+it).style.backgroundColor="#ff0000";
            }
            if( vtxDeficiVisual.toUpperCase().trim() !== 'S' && vtxDeficiVisual.toUpperCase().trim() !== 'N' ){
                document.getElementById('txdeficivisu'+it).value="#Erro!";
                document.getElementById('txdeficivisu'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if( vtxDeficiMental ==='' || vtxDeficiMental ===undefined ){
                document.getElementById('txdeficimental'+it).value="#Erro!";
                document.getElementById('txdeficimental'+it).style.backgroundColor="#ff0000";
            }
            if( vtxDeficiMental.toUpperCase().trim() !== 'S' && vtxDeficiMental.toUpperCase().trim() !== 'N' ){
                document.getElementById('txdeficimental'+it).value="#Erro!";
                document.getElementById('txdeficimental'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if( vtxDeficiIntelectual ==='' || vtxDeficiIntelectual ===undefined ){
                document.getElementById('txdeficintelectual'+it).value="#Erro!";
                document.getElementById('txdeficintelectual'+it).style.backgroundColor="#ff0000";
            }
            if( vtxDeficiIntelectual.toUpperCase().trim() !== 'S' && vtxDeficiIntelectual.toUpperCase().trim() !== 'N' ){
                document.getElementById('txdeficintelectual'+it).value="#Erro!";
                document.getElementById('txdeficintelectual'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if( vtxDeficiReabilit ==='' || vtxDeficiReabilit ===undefined ){
                document.getElementById('txdeficireabil'+it).value="#Erro!";
                document.getElementById('txdeficireabil'+it).style.backgroundColor="#ff0000";
            }
            if( vtxDeficiReabilit.toUpperCase().trim() !== 'S' && vtxDeficiReabilit.toUpperCase().trim() !== 'N' ){
                document.getElementById('txdeficireabil'+it).value="#Erro!";
                document.getElementById('txdeficireabil'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxCpf === '' || vtxCpf===undefined){
                document.getElementById('txcpf'+it).value="#Erro!";
                document.getElementById('txcpf'+it).style.backgroundColor="#ff0000";
            }
            if( vtxCpf !== '' && vtxCpf !==undefined){
                if(true){
                    validaCPF(vtxCpf);
                }else{
                    document.getElementById('txcpf'+it).value="#Erro!";
                    document.getElementById('txcpf'+it).style.backgroundColor="#ff0000";
                }
            }
            //=================================//
            if(vtxRg === '' || vtxRg===undefined){
                document.getElementById('txrg'+it).value="#Erro!";
                document.getElementById('txrg'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxUfRg ==='' || vtxUfRg ===undefined){
                document.getElementById('txufrg'+it).value="#Erro!";
                document.getElementById('txufrg'+it).style.backgroundColor="#ff0000";
            }
            var validaUFRG=false;
            var tmpUfRG=document.getElementById('txufrg'+it).value.trim();
            
            if( validarCampoUF(tmpUfRG.trim() ) === true){
                validaUFRG=true;
            }
            if(validaUFRG === false){
                document.getElementById('txufrg'+it).value="#Erro!";
                document.getElementById('txufrg'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxOrgaoEmiRg ==='' || vtxOrgaoEmiRg === undefined){
                document.getElementById('txorgaoemirg'+it).value="#Erro!";
                document.getElementById('txorgaoemirg'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxDtEmiRg === '' || vtxDtEmiRg ===undefined){
                document.getElementById('txdtemirg'+it).value="#Erro!";
                document.getElementById('txdtemirg'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxTitEleit.trim() === '' || vtxTitEleit.trim() === undefined){
                document.getElementById('txtituloeleit'+it).value="#Erro!";
                document.getElementById('txtituloeleit'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxZonaTit.trim() === '' || vtxZonaTit.trim() === undefined){
                document.getElementById('txzonaeleit'+it).value="#Erro!";
                document.getElementById('txzonaeleit'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxDtTit.trim() === '' || vtxDtTit.trim() === undefined){
               document.getElementById('txdttituloeleit'+it).value="#Erro!";
               document.getElementById('txdttituloeleit'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxSecaoTit.trim() === '' || vtxSecaoTit.trim() === undefined){
                document.getElementById('txsecaotituloeleit'+it).value="#Erro!";
                document.getElementById('txsecaotituloeleit'+it).style.backgroundColor="#ff0000";
            } 
            //=================================//
            if(vtxUfTit.trim() === '' || vtxUfTit.trim() === undefined){
                document.getElementById('txuftituloeleit'+it).value="#Erro!";
                document.getElementById('txuftituloeleit'+it).style.backgroundColor="#ff0000";
            }
            var validaUfTit=false;
            var tmpUfTit=document.getElementById('txuftituloeleit'+it).value.trim();
            
            if( validarCampoUF( tmpUfTit.trim() ) === true){
                validaUfTit=true;
            }
            if(validaUfTit === false){
                document.getElementById('txuftituloeleit'+it).value="#Erro!";
                document.getElementById('txuftituloeleit'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            
            if(vtxCtps === '' || vtxCtps === undefined){
                document.getElementById('txctps'+it).value="#Erro!";
                document.getElementById('txctps'+it).style.backgroundColor="#ff0000";   
            }
            //=================================//
            if(vtxSerieCtps === '' || vtxSerieCtps === undefined ){
                document.getElementById('txseriectps'+it).value="#Erro!";
                document.getElementById('txseriectps'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxDtEmiCtps === '' || vtxDtEmiCtps === undefined ){
                document.getElementById('txdtemictps'+it).value="#Erro!";
                document.getElementById('txdtemictps'+it).style.backgroundColor="#ff0000";
            }       
            //=================================//
            if(vtxUfCtps === '' || vtxUfCtps === undefined){
                document.getElementById('txufctps'+it).value="#Erro!";
                document.getElementById('txufctps'+it).style.backgroundColor="#ff0000";
            }
            var validaUfCtps=false;
            var tmpUfCtps=document.getElementById('txufctps'+it).value.trim();
            
            if( validarCampoUF( tmpUfCtps.trim() ) === true){
                validaUfCtps=true;
            }
            if(validaUfCtps === false){
                document.getElementById('txufctps'+it).value="#Erro!";
                document.getElementById('txufctps'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxNit ==='' || vtxNit === undefined){
                document.getElementById('txnit'+it).value="#Erro!";
                document.getElementById('txnit'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxCnh ==='' || vtxCnh===undefined){
                document.getElementById('txcnh'+it).value="#Erro!";
                document.getElementById('txcnh'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            
            if(vtxDtEmiCnh ==='' || vtxDtEmiCnh ===undefined){
                document.getElementById('txdataemicnh'+it).value="#Erro!";
                document.getElementById('txdataemicnh'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            
            var dt1 = parseInt(vtxDtEmiCnh.substring(6,11));  
            var dtValida1= ano-dt1;
            
            if(vtxDataVctoCnh === '' || vtxDataVctoCnh===undefined){
                document.getElementById('txdatavctocnh'+it).value="#Erro!";
                document.getElementById('txdatavctocnh'+it).style.backgroundColor="#ff0000";
            }
            if(vtxDataVctoCnh !== '' && vtxDataVctoCnh !== undefined){
                    if(dtValida1 < 1) {
                        document.getElementById('txdatavctocnh'+it).value="#Erro!";
                        document.getElementById('txdatavctocnh'+it).style.backgroundColor="#ff0000";
                    }
            }
            //=================================//
            if(vtxOrgaEmiCnh === '' || vtxOrgaEmiCnh===undefined){
                document.getElementById('txorgemicnh'+it).value="#Erro!";
                document.getElementById('txorgemicnh'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxDtEmiCnh==='' || vtxDtEmiCnh===undefined){
                document.getElementById('txdataemicnh'+it).value="#Erro!";
                document.getElementById('txdataemicnh'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxCategCnh ==='' || vtxCategCnh ===undefined){
                document.getElementById('txcategoriacnh'+it).value="#Erro!";
                document.getElementById('txcategoriacnh'+it).style.backgroundColor="#ff0000";
            }
            if(vtxCategCnh.toUpperCase().trim() !== 'A' && vtxCategCnh.toUpperCase().trim()!== 'B' && vtxCategCnh.toUpperCase().trim()!== 'C' && vtxCategCnh.toUpperCase().trim()!== 'D'
                && vtxCategCnh.toUpperCase().trim()!== 'E' && vtxCategCnh.toUpperCase().trim()!== 'AB' && vtxCategCnh.toUpperCase().trim()!== 'AC' && vtxCategCnh.toUpperCase().trim()!== 'AD' && vtxCategCnh.toUpperCase().trim()!== 'AE'){
                document.getElementById('txcategoriacnh'+it).value="#Erro!";
                document.getElementById('txcategoriacnh'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxUfCnh === '' || vtxUfCnh === undefined){
                document.getElementById('txufcnh'+it).value="#Erro!";
                document.getElementById('txufcnh'+it).style.backgroundColor="#ff0000";
            }
            var validaUfCNH=false;
            var tmpUfCNH=document.getElementById('txufcnh'+it).value.trim();

            if( validarCampoUF( tmpUfCNH.trim() ) === true){
                validaUfCNH=true;
            }
            if(validaUfCNH === false){
                document.getElementById('txufcnh'+it).value="#Erro!";
                document.getElementById('txufcnh'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxDtPrimeiraCnh ==='' || vtxDtPrimeiraCnh ===undefined){
                document.getElementById('txdtprimeiracnh'+it).value="#Erro!";
                document.getElementById('txdtprimeiracnh'+it).style.backgroundColor="#ff0000";
            }            
            //=================================//
            if(vtxPisPasep==='' || vtxPisPasep===undefined){
                document.getElementById('txpispasep'+it).value="#Erro!";
                document.getElementById('txpispasep'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            
            //=================================//
            if(vtxBancoPis==='' || vtxBancoPis===undefined){
               document.getElementById('txbancopis'+it).value="#Erro!";
               document.getElementById('txbancopis'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxCertireserv ==='' || vtxCertireserv===undefined){
                document.getElementById('txcertreservista'+it).value="#Erro!";
                document.getElementById('txcertreservista'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxDtEmiCertireserv ==='' || vtxDtEmiCertireserv===undefined){
                document.getElementById('txcertreservista'+it).value="#Erro!";
                document.getElementById('txcertreservista'+it).style.backgroundColor="#ff0000";
            }            
            //=================================//
            if(vtxSituMilit === '' || vtxSituMilit===undefined){
               document.getElementById('txsitumilitar'+it).value="#Erro!";
               document.getElementById('txsitumilitar'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxNumRic ==='' || vtxNumRic ===undefined){
                document.getElementById('txnumeroric'+it).value="#Erro!";
                document.getElementById('txnumeroric'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxOrgaoEmiRic==='' || vtxOrgaoEmiRic===undefined){
                document.getElementById('txorgaoemiric'+it).value="#Erro!";
                document.getElementById('txorgaoemiric'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxDtEmiRic==='' || vtxDtEmiRic===undefined){
                document.getElementById('txdtemiric'+it).value="#Erro!";
                document.getElementById('txdtemiric'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxPassaporte === '' || vtxPassaporte===undefined){
                document.getElementById('txpassaporte'+it).value="#Erro!";
                document.getElementById('txpassaporte'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxRNE==='' || vtxRNE===undefined){
                //validarErros('txrne'+it);
                document.getElementById('txrne'+it).value="#Erro!";
                document.getElementById('txrne'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxDtEmiRNE==='' || vtxDtEmiRNE===undefined){
                document.getElementById('txdtemirne'+it).value="#Erro!";
                document.getElementById('txdtemirne'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxOrgaoEmiRNE==='' || vtxOrgaoEmiRNE===undefined){
                document.getElementById('txorgaoemirne'+it).value="#Erro!";
                document.getElementById('txorgaoemirne'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxBancoPagto==='' || vtxBancoPagto===undefined){
                document.getElementById('txbancopgto'+it).value="#Erro!";
                document.getElementById('txbancopgto'+it).style.backgroundColor="#ff0000";
            }            
            //=================================//
            if(vtxAgenciaPagto==='' || vtxAgenciaPagto===undefined ){
                document.getElementById('txagenciapgto'+it).value="#Erro!";
                document.getElementById('txagenciapgto'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxConta==='' || vtxConta===undefined){
                document.getElementById('txconta'+it).value="#Erro!";
                document.getElementById('txconta'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxTpConta==='' || vtxTpConta===undefined){
                document.getElementById('txtipoconta'+it).value="#Erro!";
                document.getElementById('txtipoconta'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxBancoFgts==='' || vtxBancoFgts===undefined){
                document.getElementById('txbancopgtofgts'+it).value="#Erro!";
                document.getElementById('txbancopgtofgts'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxTipoLogra==='' || vtxTipoLogra===undefined){
                document.getElementById('txtipolograd'+it).value="#Erro!";
                document.getElementById('txtipolograd'+it).style.backgroundColor="#ff0000";
            }
            var tmpLograd=document.getElementById('txtipolograd'+it).value.trim();
            if(vtxTipoLogra!=='' && vtxTipoLogra!==undefined){
                if( validaTipoLogradouro(tmpLograd)===false ){
                    document.getElementById('txtipolograd'+it).value="#Erro!";
                    document.getElementById('txtipolograd'+it).style.backgroundColor="#ff0000";
                }
            }            
            //=================================//
          /**/  if(vtxLograRua==='' || vtxLograRua===undefined){
                document.getElementById('txlograrua'+it).value="#Erro!";
                document.getElementById('txlograrua'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxLograNum==='' || vtxLograNum===undefined){
                document.getElementById('txlogranumero'+it).value="#Erro!";
                document.getElementById('txlogranumero'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxLograComple==='' || vtxLograComple===undefined){
                document.getElementById('txlogracomplem'+it).value="#Erro!";
                document.getElementById('txlogracomplem'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxTipoBairro==='' || vtxTipoBairro===undefined){
                document.getElementById('txtipobairro'+it).value="#Erro!";
                document.getElementById('txtipobairro'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxBairro==='' || vtxBairro===undefined ){
                document.getElementById('txbairro'+it).value="#Erro!";
                document.getElementById('txbairro'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxEstadoIbge==='' || vtxEstadoIbge===undefined){
                document.getElementById('txestadoibge'+it).value="#Erro!";
                document.getElementById('txestadoibge'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxCidadeIbge==='' || vtxCidadeIbge===undefined ){
                document.getElementById('txcidadeibge'+it).value="#Erro!";
                document.getElementById('txcidadeibge'+it).style.backgroundColor="#ff0000";
            }
            if(vtxCidadeIbge==='ERROR' || vtxCidadeIbge==='ERROR'){
                document.getElementById('txcidadeibge'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxCepIbge==='' || vtxCepIbge===undefined){
                document.getElementById('txcepibge'+it).value="#Erro!";
                document.getElementById('txcepibge'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxPaisIbge==='' || vtxPaisIbge===undefined){
                document.getElementById('txpaisibge'+it).value="#Erro!";
                document.getElementById('txpaisibge'+it).style.backgroundColor="#ff0000";
            }
            if(vtxPaisIbge==='ERROR' || vtxPaisIbg==='ERROR'){
                document.getElementById('txpaisibge'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            
         /*   if(paisResiBras==='' || paisResiBras===undefined){
                alert('Atenção, campo país do residente no Brasil com valor nulo');
                document.getElementById('txpaisresidibge'+it).value="#Erro!";
                document.getElementById('txpaisibge'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxCompleIbge==='' || vtxCompleIbge===undefined ){
                document.getElementById('txcomplemibge'+it).value="#Erro!";
                document.getElementById('txcomplemibge'+it).style.backgroundColor="#ff0000";
            }
            
            //=================================//
            if(vtxNumLograIbge==='' || vtxNumLograIbge===undefined){
                document.getElementById('txnumlograibge'+it).value="#Erro!";
                document.getElementById('txnumlograibge'+it).style.backgroundColor="#ff0000";
            }   
            
             if(vtxBairroIbge==='' || vtxBairroIbge===undefined){
                document.getElementById('txbairroibge'+it).value="#Erro!";
                document.getElementById('txbairroibge'+it).style.backgroundColor="#ff0000"; 
             }
             //=================================//
             if(vtxNomeCidIbge==='' || vtxNomeCidIbge===undefined){
                 document.getElementById('txnomecidadeibge'+it).value="#Erro!";
                 document.getElementById('txnomecidadeibge'+it).style.backgroundColor="#ff0000"; 
             }
             //=================================//
             if(vtxCodPostalIbge==='' || vtxCodPostalIbge===undefined){
                 document.getElementById('txcodpostalibge'+it).value="#Erro!";
                 document.getElementById('txcodpostalibge'+it).style.backgroundColor="#ff0000"; 
             }
             //=================================//
             if(vtxDtChegEstran==='' || vtxDtChegEstran===undefined){
                 document.getElementById('txdtchegadaestrang'+it).value="#Erro!";
                 document.getElementById('txdtchegadaestrang'+it).style.backgroundColor="#ff0000"; 
             }   
             //=================================//
             if(vtxClassifiEstrang==='' || vtxClassifiEstrang===undefined){
                 document.getElementById('txclassificestrang'+it).value="#Erro!";
                 document.getElementById('txclassificestrang'+it).style.backgroundColor="#ff0000"; 
             }
             //=================================//
           */  if(vtxCasadoComBrasileiro==='' || vtxCasadoComBrasileiro===undefined){
                 document.getElementById('txcasadocombrasileiro'+it).value="#Erro!";
                 document.getElementById('txcasadocombrasileiro'+it).style.backgroundColor="#ff0000"; 
             }
             //=================================//
             if(vtxFilhosBrasileiros==='' || vtxFilhosBrasileiros===undefined){
                document.getElementById('txfilhosbrasileiros'+it).value="#Erro!";
                document.getElementById('txfilhosbrasileiros'+it).style.backgroundColor="#ff0000"; 
             }
             //=================================//
             if(vtxTelefone==='' || vtxTelefone===undefined){
                document.getElementById('txtelefone'+it).value="#Erro!";
                document.getElementById('txtelefone'+it).style.backgroundColor="#ff0000";
             }
            if(vtxTelefone!=='' && vtxTelefone !== undefined){
               var len=vtxTelefone.length;
               if(len < 10){
                   document.getElementById('txtelefone'+it).value="#Erro!";
                    document.getElementById('txtelefone'+it).style.backgroundColor="#ff0000";
               }
            }
             //=================================//
             if(vxtCelular==='' || vxtCelular===undefined){
                document.getElementById('txcelular'+it).value="#Erro!";
                document.getElementById('txcelular'+it).style.backgroundColor="#ff0000";
             }
             if(vxtCelular!=='' && vxtCelular !== undefined){
               var len=vxtCelular.length;
                if(len < 10){
                    document.getElementById('txcelular'+it).value="#Erro!";
                    document.getElementById('txcelular'+it).style.backgroundColor="#ff0000";
                }
             }
             //=================================//
             if(vtxTelContato==='' || vtxTelContato===undefined){
                document.getElementById('txtelcontato'+it).value="#Erro!";
                document.getElementById('txtelcontato'+it).style.backgroundColor="#ff0000";
             }
             if(vtxTelContato!=='' && vtxTelContato !== undefined){
               var len=vtxTelContato.length;
                if(len < 10){
                   document.getElementById('txtelcontato'+it).value="#Erro!";
                    document.getElementById('txtelcontato'+it).style.backgroundColor="#ff0000";
               }
             }
             //=================================//
             if(vtxEmail ==='' || vtxEmail===undefined){
                document.getElementById('txemail'+it).value="#Erro!";
                document.getElementById('txemail'+it).style.backgroundColor="#ff0000";
             }
             if(vtxEmail !=='' && vtxEmail !==undefined){                 
                if( vtxEmail.substr( vtxEmail-1, vtxEmail.length).trim() ==='@' ){
                    alert(vtxEmail.substr( vtxEmail-1, vtxEmail.length).trim() );
                }
                if( vtxEmail.substr(0,2).trim() ==='@' ){
                    alert(vtxEmail.substr( vtxEmail.length-1, vtxEmail.length).trim() );
                }
             }
             //=================================//
             if(vtxFuncao==='' || vtxFuncao===undefined){
                document.getElementById('txfuncao'+it).value="#Erro!";
                document.getElementById('txfuncao'+it).style.backgroundColor="#ff0000"; 
             }
             //=================================//
             if(vtxCodFuncao==='' || vtxCodFuncao===undefined){
                document.getElementById('txcodfuncao'+it).value="#Erro!";
                document.getElementById('txcodfuncao'+it).style.backgroundColor="#ff0000";  
             }
             //=================================//
             if(vtxDtAdmissao==='' || vtxDtAdmissao===undefined){
                document.getElementById('txdataadmissao'+it).value="#Erro!";
                document.getElementById('txdataadmissao'+it).style.backgroundColor="#ff0000";   
             }if( vtxDtAdmissao <= vtxDtNascto ){
                 document.getElementById('txdataadmissao'+it).value="#Erro!";
                document.getElementById('txdataadmissao'+it).style.backgroundColor="#ff0000";
             }
             //=================================//
             if(vtxSalario==='' || vtxSalario===undefined){
                document.getElementById('txsalario'+it).value="#Erro!";
                document.getElementById('txsalario'+it).style.backgroundColor="#ff0000";   
             }
             //=================================//
             if(vtxJornada==='' || vtxJornada===undefined){
                document.getElementById('txjornada'+it).value="#Erro!";
                document.getElementById('txjornada'+it).style.backgroundColor="#ff0000";   
             }
             //=================================//
             if(vtxSindicato==='' || vtxSindicato===undefined){
                document.getElementById('txsindicato'+it).value="#Erro!";
                document.getElementById('txsindicato'+it).style.backgroundColor="#ff0000";   
             }
             //=================================//
             if(vtxCodSindicato==='' || vtxCodSindicato===undefined){
                document.getElementById('txcodsindicato'+it).value="#Erro!";
                document.getElementById('txcodsindicato'+it).style.backgroundColor="#ff0000";   
             }
             //=================================//
             if(vtxCnpjSindic==='' || vtxCnpjSindic===undefined){
                document.getElementById('txcnpjsindicato'+it).value="#Erro!";
                document.getElementById('txcnpjsindicato'+it).style.backgroundColor="#ff0000";
                ValidarCNPJ(vtxCnpjSindic,it);
             }
             //=================================//
             if(vtxDataValor==='' || vtxDataValor===undefined){
                document.getElementById('txdtvalor'+it).value="#Erro!";
                document.getElementById('txdtvalor'+it).style.backgroundColor="#ff0000";   
             }
             if(vtxDataValor!=='' && vtxDataValor!==undefined){
                if(vtxDataValor  !=='1' && vtxDataValor !=='2' && vtxDataValor !=='3' && vtxDataValor !=='4'
                && vtxDataValor !=='5' && vtxDataValor !=='6' && vtxDataValor !== '7' && vtxDataValor !== '8'
                && vtxDataValor !=='9' && vtxDataValor !== '10' && vtxDataValor !== '11' && vtxDataValor !== '12'){
                    document.getElementById('txdtvalor'+it).value="#Erro!";
                    document.getElementById('txdtvalor'+it).style.backgroundColor="#ff0000";
                 }
             }
             //=================================//
             if(vtxHorarioTrab==='' || vtxHorarioTrab===undefined){
                document.getElementById('txhorariotrab'+it).value="#Erro!";
                document.getElementById('txhorariotrab'+it).style.backgroundColor="#ff0000";   
             }
             //=================================//
             if(vtxCodHorarioTrab==='' || vtxCodHorarioTrab===undefined){
                document.getElementById('txcodhorariotrab'+it).value="#Erro!";
                document.getElementById('txcodhorariotrab'+it).style.backgroundColor="#ff0000";   
             }
             //=================================//
             if(vtxIndiceHorarioTrab==='' || vtxIndiceHorarioTrab===undefined){
                document.getElementById('txindicehorariotrab'+it).value="#Erro!";
                document.getElementById('txindicehorariotrab'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxTpRegimeJornada==='' || vtxTpRegimeJornada===undefined){
                document.getElementById('txtipregimjornadtrab'+it).value="#Erro!";
                document.getElementById('txtipregimjornadtrab'+it).style.backgroundColor="#ff0000";   
            }
            if(vtxTpRegimeJornada!=='' || vtxTpRegimeJornada!==undefined){
                if( vtxTpRegimeJornada !==1 && vtxTpRegimeJornada !==2 && vtxTpRegimeJornada !==3  ){
                    document.getElementById('txtipregimjornadtrab'+it).value="#Erro!";
                    document.getElementById('txtipregimjornadtrab'+it).style.backgroundColor="#ff0000";
                }
            }
            //=================================//
            if(vtxIndicativoAdmissao==='' || vtxIndicativoAdmissao===undefined){
                document.getElementById('txindicativoadmissao'+it).value="#Erro!";
                document.getElementById('txindicativoadmissao'+it).style.backgroundColor="#ff0000";   
            }
            if(vtxIndicativoAdmissao!=='' || vtxIndicativoAdmissao!==undefined){
                if(vtxIndicativoAdmissao!==1 && vtxIndicativoAdmissao!==2 && vtxIndicativoAdmissao !==3){
                    document.getElementById('txindicativoadmissao'+it).value="#Erro!";
                    document.getElementById('txindicativoadmissao'+it).style.backgroundColor="#ff0000";
                }
            }
            //=================================//
            if(vtxNaturezaAtividade==='' || vtxNaturezaAtividade===undefined){
                document.getElementById('txnaturezaatividade'+it).value="#Erro!";
                document.getElementById('txnaturezaatividade'+it).style.backgroundColor="#ff0000";
            }
            if(vtxNaturezaAtividade!=='' || vtxNaturezaAtividade!==undefined){
                if(vtxNaturezaAtividade !== 1 || vtxNaturezaAtividade !== 2){
                    document.getElementById('txnaturezaatividade'+it).value="#Erro!";
                    document.getElementById('txnaturezaatividade'+it).style.backgroundColor="#ff0000";
                }
            }
            //=================================//
            if(vtxTipoAdmissao==='' || vtxTipoAdmissao===undefined){
                document.getElementById('txtipoadmissao'+it).value="#Erro!";
                document.getElementById('txtipoadmissao'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxCodTipoAdmissao==='' || vtxCodTipoAdmissao===undefined){
                document.getElementById('txcodtipoadmissao'+it).value="#Erro!";
                document.getElementById('txcodtipoadmissao'+it).style.backgroundColor="#ff0000";
            }
            if(vtxCodTipoAdmissao!=='' && vtxCodTipoAdmissao!==undefined){
                if(vtxCodTipoAdmissao !== '1' && vtxCodTipoAdmissao !== '2' && vtxCodTipoAdmissao !== '3'
                && vtxCodTipoAdmissao !== '4'){
                    document.getElementById('txcodtipoadmissao'+it).value="#Erro!";
                    document.getElementById('txcodtipoadmissao'+it).style.backgroundColor="#ff0000";
                }
            }
            //=================================//
            if(vtxMotivoAdmissao==='' || vtxMotivoAdmissao===undefined){
                document.getElementById('txtipoadmissao'+it).value="#Erro!";
                document.getElementById('txtipoadmissao'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxCodMotivoAdmissao==='' || vtxCodMotivoAdmissao===undefined){
                document.getElementById('txtipoadmissao'+it).value="#Erro!";
                document.getElementById('txtipoadmissao'+it).style.backgroundColor="#ff0000";
            }
            if(vtxCodMotivoAdmissao!=='' && vtxCodMotivoAdmissao!==undefined){
                if(vtxCodMotivoAdmissao !=='1' && vtxCodMotivoAdmissao !== '2'){
                    document.getElementById('txtipoadmissao'+it).value="#Erro!";
                    document.getElementById('txtipoadmissao'+it).style.backgroundColor="#ff0000";
                }
            }
            //=================================//
            if(vtxSituacaoFgts==='' || vtxSituacaoFgts===undefined ){
                document.getElementById('txsitufgts'+it).value="#Erro!";
                document.getElementById('txsitufgts'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxCodSituacaoFgts==='' || vtxCodSituacaoFgts===undefined ){
                document.getElementById('txcodsitufgts'+it).value="#Erro!";
                document.getElementById('txcodsitufgts'+it).style.backgroundColor="#ff0000";
            }else{
                if(vtxDtAdmissao > '04/10/1988' ){
                    vtxDtOpcaoFgts=vtxDtAdmissao;
                    vtxCodSituFgts=1;
                }
                if(vtxCodSituacaoFgts !== '1' && vtxCodSituacaoFgts !== '2' ){
                    document.getElementById('txcodsitufgts'+it).value="#Erro!";
                    document.getElementById('txcodsitufgts'+it).style.backgroundColor="#ff0000";
                }
            }
            //=================================//
            if(vtxDtOpcaoFgts==='' || vtxDtOpcaoFgts===undefined ){
                document.getElementById('txdtopcaofgts'+it).value="#Erro!";
                document.getElementById('txdtopcaofgts'+it).style.backgroundColor="#ff0000";
            }if(vtxDtOpcaoFgts!=='' && vtxDtOpcaoFgts!==undefined){
                if(vtxDtOpcaoFgts >= vtxDtAdmissao){
                    if(vtxDtAdmissao > '04/10/1988' ){
                        vtxDtOpcaoFgts=vtxDtAdmissao;
                    }
                    if(vtxDtAdmissao < '05/10/1988' ){
                        vtxDtOpcaoFgts='05/10/1988';
                    }
                }
            }//=================================//
            if(vtxMotivoAdmissao==='' || vtxMotivoAdmissao===undefined ){
                document.getElementById('txmotivoadmissao'+it).value="#Erro!";
                document.getElementById('txmotivoadmissao'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxCodMotivoAdmissao==='' || vtxCodMotivoAdmissao===undefined ){
                document.getElementById('txcodmotivoadmissao'+it).value="#Erro!";
                document.getElementById('txcodmotivoadmissao'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxSituacaoFgts==='' || vtxSituacaoFgts===undefined ){
                document.getElementById('txsitufgts'+it).value="#Erro!";
                document.getElementById('txsitufgts'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxCodSituacaoFgts==='' || vtxCodSituacaoFgts===undefined ){
                document.getElementById('txcodsitufgts'+it).value="#Erro!";
                document.getElementById('txcodsitufgts'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxDtOpcaoFgts==='' || vtxDtOpcaoFgts===undefined ){
                document.getElementById('txdtopcaofgts'+it).value="#Erro!";
                document.getElementById('txdtopcaofgts'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxSituacaoRais==='' || vtxSituacaoRais===undefined ){
                document.getElementById('txsiturais'+it).value="#Erro!";
                document.getElementById('txsiturais'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxCodSituacaoRais==='' || vtxCodSituacaoRais===undefined ){
                document.getElementById('txcodsiturais'+it).value="#Erro!";
                document.getElementById('txcodsiturais'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
             if(vtxVinculoRais==='' || vtxVinculoRais===undefined ){
                document.getElementById('txvinculorais'+it).value="#Erro! "+vtxVinculoRais;
                document.getElementById('txvinculorais'+it).style.backgroundColor="#ff0000";
            } 
            //=================================//
            if(vtxCodVinculoRais==='' || vtxCodVinculoRais===undefined ){
                document.getElementById('txcodvinculorais'+it).value="#Erro!";
                document.getElementById('txcodvinculorais'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxContribSindical==='' || vtxContribSindical===undefined ){
                document.getElementById('txcontribsindical'+it).value="#Erro!";
                document.getElementById('txcontribsindical'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxCodContribSindical==='' || vtxCodContribSindical===undefined ){
                document.getElementById('txcodcontribsindical'+it).value="#Erro!";
                document.getElementById('txcodcontribsindical'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxNumeroRegClassOc==='' || vtxNumeroRegClassOc===undefined ){
                document.getElementById('txnumeroregorgclasseoc'+it).value="#Erro!";
                document.getElementById('txnumeroregorgclasseoc'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxOrgemssoroc==='' || vtxOrgemssoroc===undefined ){
                document.getElementById('txorgaoemissoroc'+it).value="#Erro!";
                document.getElementById('txorgaoemissoroc'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxDtEmissOc==='' || vtxDtEmissOc===undefined ){
                document.getElementById('txdtemissoc'+it).value="#Erro!";
                document.getElementById('txdtemissoc'+it).style.backgroundColor="#ff0000";
            }
            //=================================//
            if(vtxDtValidOc==='' || vtxDtValidOc===undefined ){
                document.getElementById('txdtvalidadeoc'+it).value="#Erro!";
                document.getElementById('txdtvalidadeoc'+it).style.backgroundColor="#ff0000";
            }
            if(vtxDtValidOc!=='' && vtxDtValidOc!==undefined ){
                var dt3=parseInt(new Date());
                dt3 = parseInt(vtxDtValidOc.substring(6,11));  
                var dtValida3= ano-dt3;
                //alert('Dt OC:' + dtValida3);
            }
        }
    }
   
    </script>
    
    <script type="text/javascript">
        function validarCampoUF( localUF ){
            
            strUF=localUF.toString().trim();
            var retorno= false; 
            
            var estados = new Array(27);
            estados[0]="AC";
            estados[1]="AL";
            estados[2]="AM";
            estados[3]="AP";
            estados[4]="BA";
            estados[5]="CE";
            estados[6]="DF";
            estados[7]="ES";
            estados[8]="GO";
            estados[9]="MA";
            estados[10]="MG";
            estados[11]="MS";
            estados[12]="MT";
            estados[13]="PA";
            estados[14]="PB";
            estados[15]="PE";
            estados[16]="PI";
            estados[17]="PR";
            estados[18]="RJ";
            estados[19]="RN";
            estados[20]="RO";
            estados[21]="RR";
            estados[22]="RS";
            estados[23]="SC";
            estados[24]="SE";
            estados[25]="SP";
            estados[26]="TO";
            var tamanho=estados.length;
            //alert('strUF (função validaruf) ' +strUF.trim());
            
            if ( strUF === '' || strUF === undefined) {
                //alert('Atenção, campo estado natal com valor nulo *');
                return false;
            }
            
            for (x=0; x <tamanho; x++){
                if( estados[x].toUpperCase().trim() === strUF.toUpperCase().trim() ){
                    retorno = true;
                    break;    
                }
            }
            if ( retorno === false ){
                retorno=false;
            }else{
                retorno=true;
            }
            return retorno;
        }
    </script>
    
    <script type="text/javascript">
        //===================================
        function veriDatas(){
            var vtxDataVctoCnh=document.getElementById('dtVenctoCnhTx').value;
            now = new Date();
            var dt = parseInt(vtxDataVctoCnh.substring(6,11));
            var dt1= parseInt(new Date());
            var ano = now.getFullYear();
            var dtValida= ano-dt;
          
            var dt1 = parseInt(vtxDataVctoCnh.substring(6,11));  
            var dtValida1= ano-dt1;
            alert('Dt cnh:' + dtValida1);
            
            if(vtxDataVctoCnh === '' || vtxDataVctoCnh===undefined){
                alert('Atenção, campo data de vencimento da CNH com  valor nulo * ' + vtxDataVctoCnh);
            }
            if(vtxDataVctoCnh !== '' || vtxDataVctoCnh !== undefined){   
                    if(dtValida1 < 1) {
                        alert('Data de Vencimento da CNH ' +dtValida+ ' é inválida');
                    }else{ alert('Ano de Vencimento da CNH:! ' +dtValida); }
            }
        }
    </script>
    
    <script type="text/javascript">
        
        function validaTipoLogradouro(tplogra){
            
            var tipoLogra= tplogra.toString().trim();
            var retorno=false;
            var codLogra= new Array(40);
            var nomeLogra = new Array(40);
            
            codLogra[1]="AER";
            codLogra[2]="AL";
            codLogra[3]="A";
            codLogra[4]="AV";
            codLogra[5]="BAL";
            codLogra[6]="BL";
            codLogra[7]="CPO";
            codLogra[8]="CH";
            codLogra[9]="COL";
            codLogra[10]="COND";
            codLogra[11]="CJ";
            codLogra[12]="DT";
            codLogra[13]="ESP";
            codLogra[14]="ETC";
            codLogra[15]="EST";
            codLogra[16]="FAV";
            codLogra[17]="FAZ";
            codLogra[18]="FRA";
            codLogra[19]="GAL";
            codLogra[20]="GJA";
            codLogra[21]="JD";
            codLogra[22]="LD";
            codLogra[23]="LGO";
            codLogra[24]="LGA";
            codLogra[25]="LRG";
            codLogra[26]="LOT";
            codLogra[27]="MRO";
            codLogra[28]="NUC";
            codLogra[29]="O";
            codLogra[30]="PRQ";
            codLogra[31]="PSA";
            codLogra[32]="PAT";
            codLogra[33]="PC";
            codLogra[34]="PR";
            codLogra[35]="Q";
            codLogra[36]="REC";
            codLogra[37]="RES";
            codLogra[38]="ROD";
            codLogra[39]="R";
            codLogra[40]="ST";
            codLogra[41]="SIT";
            codLogra[42]="TV";
            codLogra[43]="TRC";
            codLogra[44]="TRV";
            codLogra[45]="VLE";
            codLogra[46]="VER";
            codLogra[47]="V";
            codLogra[48]="VD";
            codLogra[49]="VLA";
            codLogra[50]="VL";
    //==========================================================================
            nomeLogra[1]="Aeroporto";
            nomeLogra[2]="Alameda";
            nomeLogra[3]="Área";
            nomeLogra[4]="Avenida";
            nomeLogra[5]="Balneário";
            nomeLogra[6]="Bloco";
            nomeLogra[7]="Campo";
            nomeLogra[8]="Chácara";
            nomeLogra[9]="Colônia";
            nomeLogra[10]="Condomínio";
            nomeLogra[11]="Conjunto";
            nomeLogra[12]="Distrito";
            nomeLogra[13]="Esplanada";
            nomeLogra[14]="Estação";
            nomeLogra[15]="Estrada";
            nomeLogra[16]="Favela";
            nomeLogra[17]="Fazenda";
            nomeLogra[18]="Feira";
            nomeLogra[19]="Galeria";
            nomeLogra[20]="Granja";
            nomeLogra[21]="Jardim";
            nomeLogra[22]="Ladeira";
            nomeLogra[23]="Lago";
            nomeLogra[24]="Lagoa";
            nomeLogra[25]="Largo";
            nomeLogra[26]="Loteamento";
            nomeLogra[27]="Morro";
            nomeLogra[28]="Núcleo";
            nomeLogra[29]="Outros";
            nomeLogra[30]="Parque";
            nomeLogra[31]="Passarela";
            nomeLogra[32]="Pátio";
            nomeLogra[33]="Praça";
            nomeLogra[34]="Praia";
            nomeLogra[35]="Quadra";
            nomeLogra[36]="Recanto";
            nomeLogra[37]="Residencial";
            nomeLogra[38]="Rodovia";
            nomeLogra[39]="Rua";
            nomeLogra[40]="Setor";
            nomeLogra[41]="Sítio";
            nomeLogra[42]="Travessa";
            nomeLogra[43]="Trecho";
            nomeLogra[44]="Trevo";
            nomeLogra[45]="Vale";
            nomeLogra[46]="Vereda";
            nomeLogra[47]="Via";
            nomeLogra[48]="Viaduto";
            nomeLogra[49]="Viela";
            nomeLogra[50]="Vila";
            
            var tamanhoCod=codLogra.length;
            //var tamanhoNome=nomeLogra.length;
            
            for(var it = 1; it<tamanhoCod; ++it ){
                tipoLogra=tplogra+it.value;
                
                if(tipoLogra.toUpperCase().trim() !== nomeLogra[it].toUpperCase().trim() || tipoLogra.toUpperCase().trim() !== codLogra[it].toUpperCase().trim() ){
                    //alert('Inesperado --- --- --- Logradouro: ' + tplogra.value + ' || ' + tipoLogra);
                }else{ alert('Logradouro: ' + tplogra.value + ' || ' + tipoLogra ); retorno = true; }
            }
            return retorno;
        }
    </script>
    
    <script type="text/javascript">
        var contCNPJ = 0;
        function ValidarCNPJ(ObjCnpj, iterador){
            var cnpj = ObjCnpj.value;  //txcnpjsindicato
            var valida = new Array(6,5,4,3,2,9,8,7,6,5,4,3,2);
            var dig1= new Number;
            var dig2= new Number;
            exp = /\.|\-|\//g;
            cnpj = cnpj.toString().replace( exp, "" );
            var digito = new Number(eval(cnpj.charAt(12)+cnpj.charAt(13)));

        if (cnpj === "00000000000000" || cnpj === "11111111111111" || 
         cnpj === "22222222222222" || cnpj === "33333333333333" || 
         cnpj === "44444444444444" || cnpj === "55555555555555" || 
         cnpj === "66666666666666" || cnpj === "77777777777777" || 
         cnpj === "88888888888888" || cnpj === "99999999999999")
        {
            var obj = eval("document.forms[0].txcnpjsindicato"+iterador);
            alert('CNPJ Invalido. Favor corrigir');
            obj.focus();
            obj.select();
            var limpa="";
            obj.val(limpa);
            contCNPJ = 1;
            return false;
        }
        for(i = 0; i<valida.length; i++){
                dig1 += (i>0? (cnpj.charAt(i-1)*valida[i]):0);
                dig2 += cnpj.charAt(i)*valida[i];
        }
        dig1 = (((dig1%11)<2)? 0:(11-(dig1%11)));
        dig2 = (((dig2%11)<2)? 0:(11-(dig2%11)));

        if(((dig1*10)+dig2) !== digito && cnpj !== 0){
            var obj = eval("document.forms[0].txcnpjsindicato"+iterador);
            alert('CNPJ Invalido. Favor corrigir');
            alert(cnpj);
            obj.focus();
            obj.select();
            var limpa="";
            obj.val(limpa);
            contCNPJ = 1;
            return false;
        }
    }
    
    // DEFININDO AS REGRAS DE VALIDACAO DO CPF
    function validaCPF(s) {
     if (s === "11111111111" || s === "22222222222" || s === "33333333333"
       || s === "44444444444" || s === "55555555555"
       || s === "66666666666" || s === "77777777777"
       || s === "88888888888" || s === "99999999999"
       || s === "00000000000") {
      return false;
     }
     var c = s.substr(0, 9);
     var dv = s.substr(9, 2);
     var d1 = 0;
     for (var i = 0; i < 9; i++) {
      d1 += c.charAt(i) * (10 - i);
     }
     if (d1 === 0)
      return false;
     d1 = 11 - (d1 % 11);
     if (d1 > 9)
      d1 = 0;
     if (dv.charAt(0) !== d1) {
      return false;
     }
     d1 *= 2;
     for (var i = 0; i < 9; i++) {
      d1 += c.charAt(i) * (11 - i);
     }
     d1 = 11 - (d1 % 11);
     if (d1 > 9)
      d1 = 0;
     if (dv.charAt(1) !== d1) {
      return false;
     }
     return true;
    }
   
    </script>
    
    <input type="button" id="bt3" name="btn4" value="Validar" onclick="validaCampo()">
    <input type="button" id="bt7" name="btn8" value="Nacionalidade" onclick="veriPaisNacionalidade('Brasil')">

</body>
</html>