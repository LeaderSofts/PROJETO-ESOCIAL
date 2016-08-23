<%-- 
    Document   : trabalhador
    Created on : 15/08/2016, 20:11:28
    Author     : Quintiliano
--%>

<%@page import="java.sql.SQLException"%>
<%@page import="java.util.List"%>
<%@page import="java.util.ArrayList"%>
<%@page import="java.sql.ResultSet"%>
<%@page import="java.sql.PreparedStatement"%>
<%@page import="java.sql.Connection"%>
<%@page import="java.sql.DriverManager"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>


<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>e-social content</title>
    </head>
    
    <script type="text/javascript">
            function myFunction(){ // MÉTODO GET DOS FIELDS
                document.getElementById("txtNome").value=val;
                document.getElementById("txtId").value=info;
            }
            function getValueTx(){ // MÉTODO GET DO FIELD
                document.getElementById("txtNome").value=infos;
            }
            
            function novoArquivo(){ // NOVO ARQUIVO
                window.open("Teste.jsp","e-social content",windowFeatures);
            }
            function nova(){ // NOVA PÁGINA
                location.href=" trabalhadores.jsp";
            }
        </script>
        
        <!-- CÓDIGO JAVA QUE FAZ A CONEXÃO COM A BASE DE DADOS E QUERY-->        
        <%
         int id=0;
         String val="";
         String user="sa";
         String pass="foxplan";
         String dbase="FoxplanTeste";
         String driver="com.microsoft.sqlserver.jdbc.SQLServerDriver";
         String url="jdbc:sqlserver://localhost:1433;user="+user+";password="+pass+";databaseName="+dbase+";";
         String sql="SELECT dbo.PPESSOA.Codigo [COD_PESSOA], dbo.PPESSOA.NOME AS [NOME], dbo.PPESSOA.REGPROFISSIONAL [REGPREV] FROM PPESSOA, PFUNC WHERE PPESSOA.CODIGO = PFUNC.CODPESSOA";
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
            String ufTitulo="";  //ESTELEIT
            
              
           String sqlView = "SELECT * FROM View1";
           pstmt = con.prepareStatement(sqlView);
           reset = pstmt.executeQuery();
           int element = 0;
           List<Integer> lista = new ArrayList();
           int tamanhoQuery=lista.size();
           int size=0;
            
            try{
                reset.last();
                size=reset.getRow();
                reset.beforeFirst();
                javax.swing.JOptionPane.showMessageDialog(null,"Tamanho da lista: " +  size);
            }catch(Exception ex){
                ex.fillInStackTrace();
            }
            String tamanhoRetorno="0000001";
            //String tamanhoRetorno=request.getParameter("valor");
           
            if( reset.next() ){
                chapa=reset.getString("CHAPA");
                tipoRegPrev=reset.getString("TPREGIMEPREV");
                //String tipoRegtrab=reset.getString("TPREGTRAB");
                tipoTrabalhador=reset.getString("CODTIPO");
                nome=reset.getString("NOMEF");
                dtNascto=reset.getString("DATANASCIMENTO");
                corRaca=reset.getString("CORRACA");
                nacionalidade=reset.getString("NACIONALIDADE");
                estadoNatal=reset.getString("ESTADONATAL");
                naturalidade=reset.getString("NATURALIDADE");
                
                cpf=reset.getString("CPF");
                //CONTINUAR AQUI
                corRaca=reset.getString("CORRACA");
                nacionalidade=reset.getString("NACIONALIDADE");
                estadoNatal=reset.getString("ESTADONATAL");
                naturalidade=reset.getString("NATURALIDADE");
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
                System.out.println(naturalidade);
                System.out.println(defiReabilitada);
                System.out.println(cpf);
                System.out.println(rg);
                System.out.println(ufRg);
                System.out.println(oeRg);
                System.out.println(dtEmiRg);
                
            }else{
                javax.swing.JOptionPane.showMessageDialog(null, "No more rows!");
            }
          %>
        
          <script>
              function validaNulidade(){
                
                    if(matri===""){
                        alert("Por favor informe a matrícula");
                    }
                    if(tipoRegPrev===""){
                        alert("Por favor informe o regime previdenciário");
                    }
                    if(tipoRegTrab===""){
                        alert("Por favor informe o regime trabalhista");
                    }
                    if(tipoTrabalhador===""){
                        alert("Por favor informe o tipo de trabalhador");
                    }
                    if(nome===""){
                        alert("Por favor informe o nome");
                    }
                    if(dtNascto===""){
                        alert("Por favor informe a data de nascimento");
                    }
                    if(corRaca===""){
                        alert("Por favor informe a cor/raça");
                    }
                    if(nacionalidade===""){
                        alert("Por favor informe a nacionalidade");
                    }
                    if(estadoNatal===""){
                        alert("Por favor informe o estado natal");
                    }
                    if(naturalidade===""){
                        alert("Por favor informe a naturalidade");
                        out.print("Por favor informe a naturalidade");
                        
                            //javax.swing.JOptionPane.showMessageDialog(null,"Campo naturalidade nulo!");
                        
                    }
            }
          </script>
          
        <h1>Admissão de Trabalhador</h1>
        <form name="form1" method="post" action="trabalhadores.jsp">
            
            <p> <label id="lblMatri" > MATRÍCULA: </label>
               <input type="text" id=txtMatri" name="txtMatri" size="40" maxlength="40" value="<% out.println(chapa); %>">
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
            
            
            
            <p>
                <input type="button" name="mostrar" id="id1" value="Enviar" onclick="novoArquivo()">
                <input type="button" name="trab" id="id2" value="Trabalhadores" onclick="nova()">
                <input type="button" name="valida1" id="id3" value="Valida nulo" onclick="validaNulidade()">    
                <!--<input type="button" name="tabela" id="id4" value="Tabela" onclick="inserirLinhaTabela()">-->
                
            </p>
            
        </form>
        
        <p> &nbsp; </p>
                
     <!-- TABELA DINÂMICA -->
        <script type="text/javascript" src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
        <!--<script type="text/javascript" src="jquery.js"> </script>-->
        <!--<script type="text/javascript" src="jquery.dataTables.js"></script>-->
        
        <!--   TABELA DATATABLE DE EXEMPLO-->
        <script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
        <script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/dataTables.bootstrap.min.js"></script>
        <!--   TABELA DATATABLE DE EXEMPLO-->
        
        <style type="text/css">
           #corpo{margin:0 auto; padding:0; width: 1260px; background:#f4f4f4; height:500px;}
        </style>
        
        <!--<input type="text" id="query" name="txtQuery" size="1" maxlength="40" value="<% out.println(tamanhoRetorno); %>"-->
        
    <div id="corpo">       
        <!--border="0"  cellspacing="0" cellpadding="0-->
        <table cellspacing="0"  cellpadding ="0" border="1" id="tabela1">
            <thead>
	 	<tr>
                    <th> NOME: <input type="text" id="txnome" name="txtNome1" size="25" maxlength="25" value= "<% out.println(nome); %>"> </th>
                    <th> CHAPA: <input type="text" id="txchapa" name="txtChapa1" size="25" maxlength="25" value="<% out.println(chapa); %>"> </th>
                    <th> REGIME PREVIDENCIÁRIO: <input type="text" id="txregprev" name="txtRegPrev1" size="24" maxlength="40" value="<% out.println(tipoRegPrev); %>"> </th>
                    <th> DTNASCTO <input type="text" id="txtnascto" name="txtDtnascto1" size="25" maxlength="25" value="<% out.println(dtNascto); %>"> </th>
                    <th> COR/RAÇA <input type="text" id="txtcorraca" name="txtCorRaca1" size="25" maxlength="25" value="<% out.println(corRaca); %>"> </th>
                    <th> TIPO DE TRABALHADOR <input type="text" id="txtipotrab" name="txtTipoTrab1" size="25" maxlength="25" value="<% out.println(tipoTrabalhador); %>"> </th>
		</tr>
            </thead>
              
             <tbody>
                 <tr>

                 </tr>                      
            </tbody>
                    
                
        </table>
    </div>
              
    <script language="javascript">
        $(document).ready( function(){ } );
              //$('#tabela1').dataTable();  
              //getQuerySize();
    </script>                
       
    <!--<input type="button" id="bt1" name="btn2" value="tabelinha2" onclick="addRow()">-->
    
    <!--<script src="Scripts/jquery-1.10.2.min.js"></script>-->
    
    <script src="http://code.jquery.com/jquery-1.10.2.min.js"></script>
        <script> $(document).ready(function () {
            InserirLinhaNoFim();
        });
        
        var a="";
        var b="";
        var c="";
        
        function InserirLinhaNoFim() {
            // inclui uma nova linha no fim da tabela
            var nomejs=document.getElementById('txnome').value;
            var chapajs=document.getElementById('txchapa').value;
            var regjs=document.getElementById('txtipotrab').value;
            
            for(var count=0; count<10; count++){
                novaLinha = "<tr>" +
                "<td>  <input type='text' id='tabTxtNome"+count+"' name='tabTxtNome'"+count+" size='25' value='"+nomejs+"'</td>" +
                "<td>  <input type='text' id='tabTxtMatri'"+count+"' name='tabTxtMatri' size='25'value='" +chapajs+"'</td>" +
                "<td>  <input type='text' id='tabTxtRegPrev'"+count+"' name='tabTxtRegPrev' size='25' value='"+regjs+"'</td>" +
                "</tr>";
                $('#tabela1> tbody > tr:last').after(novaLinha);
            }
            a=nomejs; b=chapajs; c=regjs;
        }
        
        function validaCampo(){
                    
//            var d=document.getElementById('tabTxtNome0').value;
//            var e=document.getElementById('tabTxtNome1').value;
//            var f=document.getElementById('tabTxtNome2').value;
//            var g=document.getElementById('tabTxtNome3').value;
//            var h=document.getElementById('tabTxtNome4').value;
//            var i=document.getElementById('tabTxtNome5').value;
//            alert(d);
//            alert(e);
//            alert(f);
//            alert(g);
//            alert(h);
//            alert(i);
//            
//1)            
//    "Matrícula atribuída ao trabalhador pela empresa ou, no caso de 
//    servdor público, a matrícula constante no Sistema de Administração de Recursos Humanos do órgão. 
//    Validação: O valor informado não pode conter a expressão 'eSocial' nas 7 (sete) primeiras posições. 
//
//*********************************
//2)

//USE FoxplanTeste
//SELECT dbo.PFUNC.TPREGIMEPREV FROM dbo.PFUNC WHERE PFUNC.TPREGIMEPREV <> NULL AND PFUNC.TPREGIMEPREV <> ''
//*********************************
//3)
//Tipo de regime trabalhista 
//1 - CLT - Consolidação das Leis de Trabalho e legislações trabalhistas específicas; 
//2 - RJP - Regime Jurídico Próprio. 
//Valores Válidos: 1, 2. 

//*********************************
//4) PFUNC.CODTIPO <> NULL

//5) PFUNC.NOME (NÃO NULO)

//6) IDADE MÍNIMA DE 15 ANOS

//7)

            
            var v1=document.getElementById('txnome').value;
            var v2=document.getElementById('txchapa').value;
            var v3=document.getElementById('txtipotrab').value;
            var v4=document.getElementById('txtipotrab').value;
//=================================////=================================////=================================//            
            if( v1.substring(0,7) === "eSocial"){
                alert( 'Valor "eSocial" não pode ser aceito! ' + v1.substring(0,7) );
            }
            if( v1==="" ){
                alert('Atenção, campo nome com  valor nulo *');
            }
            if( v1=== document.getElementById('txtNome').value ){
                alert('OK! Valores iguais! Resultado esperado!');
            }
            
            //=================================//
            //v2 =  v2.substring(4,5);
            //alert('V2: ' +v2 );
            
            if(v2==="" ){
                alert('Atenção, campo chapa com  valor nulo *');
            }
            if(v2 !== '1' || v2 !== '2' || v2 !== '3'){
                alert('Valor "'+v2+'" inválido');
            }else{
                alert('OK! Valor "'+v2+"' aceito'");
            }
            //=================================//
            v3 =  v3.substring(0,1);
            alert('V3: ' +v3 );
            if(v3==="" ){
                alert('Atenção, campo regime previdenciário com  valor nulo *');
            }if(v3 !== 1 || v3 !== 2 ){
                alert('Valor "'+v2+'" inválido');
            }
            if(v3 === 1 || v3 === 2 ){
                alert('OK! Valor "'+v3+"' aceito'");
            }else{ alert('Não pode ser o ' +v3); }
            
            if(v3==='N'){
                alert('Acertou!' + v3);
            }
            //=================================//
            
        }
   
    </script>
    
    <input type="button" id="bt2" name="btn3" value="Tabela" onclick="InserirLinhaNoFim()">
    <input type="button" id="bt3" name="btn4" value="Validar" onclick="validaCampo()">
    

    </body>
</html>
