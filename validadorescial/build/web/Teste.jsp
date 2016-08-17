<%-- 
    Document   : trabalhador
    Created on : 15/08/2016, 20:11:28
    Author     : Quintiliano
--%>

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
    
    <body>
        
        <script>
            function myFunction(){ // MÉTODO GET DOS FIELDS
                document.getElementById("txtNome").value=val;
                document.getElementById("txtId").value=info;
            }
            function getValueTx(){ // MÉTODO GET DO FIELD
                document.getElementById("txtNome").value=infos;
            }
            function doSubmit() {
                //document.forms.action;
            }
            function novoArquivo(){ // NOVO ARQUIVO
                window.open("Teste.jsp","e-social content",windowFeatures);
            }
            function nova(){ // NOVA PÁGINA
                location.href=" trabalhadores.jsp";
            }
            
            function outraFunction(){
                <%
                    if(1>0){
                        System.out.println("1+1=2");
                    }
                %>
            }
            
        </script>
        
        <!-- CÓDIGO JAVA QUE FAZ A CONEXÃO COM A BASE DE DADOS E QUERY-->        
        <%
         //String infor = request.getParameter("txtNome");
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
            String matri="";
            String tipoRegPrev="";
            String tipoRegtrab="";
            String tipoTrabalhador="";
            String nome="";
            String dtNascto="";
            String corRaca="";
            String nacionalidade="";
            String estadoNatal="";
            String naturalidade="";
              
           String sqlView = "SELECT * FROM View1";
            pstmt = con.prepareStatement(sqlView);
            reset = pstmt.executeQuery();
            
            if( reset.next() ){
                matri=reset.getString("MATRI");
                tipoRegPrev=reset.getString("TPREGPREV");
                //String tipoRegtrab=reset.getString("TPREGTRAB");
                tipoTrabalhador=reset.getString("TIPOTRAB");
                nome=reset.getString("NOME");
                dtNascto=reset.getString("DATANASCIMENTO");
                corRaca=reset.getString("CORRACA");
                nacionalidade=reset.getString("NACIONALIDADE");
                estadoNatal=reset.getString("ESTADONATAL");
                naturalidade=reset.getString("NATURALIDADE");
                System.out.println(matri);
                System.out.println(tipoRegPrev);
                //System.out.println(tipoRegtrab);
                System.out.println(tipoTrabalhador);
                System.out.println(nome);
                System.out.println(dtNascto);
                System.out.println(corRaca);
                System.out.println(nacionalidade);
                System.out.println(estadoNatal);
                System.out.println(naturalidade);
            }else{
                javax.swing.JOptionPane.showMessageDialog(null, "No more rows!");
            }
            
          %>
        
        <h1>Admissão de Trabalhador</h1>
        <form name="form1" method="post" action="trabalhadores.jsp">
            
            
            <p> <label id="lblMatri" > MATRÍCULA: </label>
               <input type="text" id="nome" name="txtMatri" size="40" maxlength="40" value="<% out.println(val); %>">
            </p>
            
            <p> <label id="lblRegPrev" > TIPO DE REGIME PREVIDENCIÁRIO: </label>
               <input type="text" id="nome" name="txtRegPrev" size="40" maxlength="40" value="<% out.println(tipoRegPrev); %>">
            </p>
            
            <p> <label id="lblRegTrab" > TIPO DE REGIME TRABALHISTA: </label>
               <input type="text" id="nome" name="txtRegTrab" size="40" maxlength="40" value="<% out.println(tipoRegtrab); %>">
            </p>
            
            <p> <label id="lblTipoTrab" > TIPO DE TRABALHADOR: </label>
               <input type="text" id="nome" name="txtTipoTrab" size="40" maxlength="40" value="<% out.println(tipoTrabalhador); %>">
            </p>
            
            <p> <label id="lblNome" > NOME: </label>
               <input type="text" id="nome" name="txtNome" size="40" maxlength="40" value="<% out.println(nome); %>">
            </p>
            
            <p> <label id="lblDtnascto" > DATA DE NASCIMENTO: </label>
               <input type="text" id="nome" name="txtDtnascto" size="40" maxlength="40" value="<% out.println(dtNascto); %>">
            </p>
            
            <p> <label id="lblDtnascto" > COR/RAÇA: </label>
               <input type="text" id="nome" name="txtCorRaca" size="40" maxlength="40" value="<% out.println(corRaca); %>">
            </p>
            
            <p> <label id="lblDtnascto" > NACIONALIDADE: </label>
               <input type="text" id="nome" name="txtNacionalidade" size="40" maxlength="40" value="<% out.println(nacionalidade); %>">
            </p>
            
            <p> <label id="lblDtnascto" > ESTADO NATAL: </label>
               <input type="text" id="nome" name="txtEstadoNatal" size="40" maxlength="40" value="<% out.println(estadoNatal); %>">
            </p>
            
            <p> <label id="lblDtnascto" > NATURALIDADE: </label>
               <input type="text" id="nome" name="txtEstadoNatal" size="40" maxlength="40" value="<% out.println(naturalidade); %>">
            </p>
            
            
            <p>
                <input type="button" name="mostrar" id="mostrar" value="Enviar" onclick="novoArquivo()" >
                <input type="button" name="trab" id="id2" value="Trabalhadores" onclick="nova()" >

                >
            </p>
            
        </form>
        
        <p> &nbsp; </p>
        
    </body>
</html>
