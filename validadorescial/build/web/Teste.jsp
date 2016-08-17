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
         int infos=0;
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
         while(reset.next() ){
            val=reset.getString("NOME");
            infos=reset.getInt("COD_PESSOA");
           //if( i <= 3){
            //javax.swing.JOptionPane.showMessageDialog(null,"Nome: " + val);
            //javax.swing.JOptionPane.showMessageDialog(null,"Id: " + infos);
            //System.out.println("Nome: " + val);
           //}
           i++;
         }
         String a=val;
         int b=infos;
         //javax.swing.JOptionPane.showMessageDialog(null, "Val: "+a+ " Infos: " +b );
        %>
        <!-- CÓDIGO JAVA QUE SETA O VALOR NA INPUT_TEXT -->
        <% 
         //request.setAttribute("nomeInfo", valor);
         String valor="";         
         //String sqlTmp0="SELECT dbo.PPESSOA.Codigo [COD_PESSOA], dbo.PPESSOA.NOME AS [NOME], dbo.PPESSOA.REGPROFISSIONAL [REGPREV] FROM PPESSOA, PFUNC WHERE PPESSOA.NOME='"+request.getParameter("txtNome")+"' AND PPESSOA.CODIGO = PFUNC.CODPESSOA";
         String sqlTmp1="SELECT dbo.PPESSOA.Codigo [COD_PESSOA], dbo.PPESSOA.NOME AS [NOME], dbo.PPESSOA.REGPROFISSIONAL [REGPREV] FROM PPESSOA, PFUNC WHERE PPESSOA.NOME='"+a+"' AND PPESSOA.CODIGO = PFUNC.CODPESSOA";
         pstmt = con.prepareStatement(sqlTmp1);
         reset = pstmt.executeQuery();
         if(reset.next() == true){
          %> <p> <%=reset.getString("NOME")%> <%valor=reset.getString("NOME"); javax.swing.JOptionPane.showMessageDialog(null, valor + "El Shaday! Kadosh!");}else{
          javax.swing.JOptionPane.showMessageDialog(null,"Falha na consulta... " + "o nome é " + val.trim() + " Id: " + infos);
          javax.swing.JOptionPane.showMessageDialog(null, "Sem mais índices!");
} %> </p>
        
        
        
        <h1>Admissão de Trabalhador</h1>
        <form name="form1" method="post" action="trabalhadores.jsp">
            
            <p> <label id="1" > ID: </label> 
                <input type="text" id="id"  name="txtId"  size="40" maxlength="40" value="<% out.println(infos); %>">
            </p>
            
            <p> <label id="2" > NOME: </label>
               <input type="text" id="nome" name="txtInfo" size="40" maxlength="40" value="<% out.println(val); %>">
            </p>
            
            <p>
                <input type="button" name="mostrar" id="mostrar" value="Enviar" onclick="novoArquivo()" >
                <input type="button" name="trab" id="id2" value="Trabalhadores" onclick="nova()" >
                <input type="button" name="trab" id="id2" value="Trabalhadores" onclick="nova()" >
                <>
            </p>
            
        </form>
        
        <p> &nbsp; </p>
        
    </body>
</html>
