package org.apache.jsp;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;
import java.sql.ResultSet;
import java.sql.PreparedStatement;
import java.sql.Connection;
import java.sql.DriverManager;

public final class Teste_jsp extends org.apache.jasper.runtime.HttpJspBase
    implements org.apache.jasper.runtime.JspSourceDependent {

  private static final JspFactory _jspxFactory = JspFactory.getDefaultFactory();

  private static java.util.List<String> _jspx_dependants;

  private org.glassfish.jsp.api.ResourceInjector _jspx_resourceInjector;

  public java.util.List<String> getDependants() {
    return _jspx_dependants;
  }

  public void _jspService(HttpServletRequest request, HttpServletResponse response)
        throws java.io.IOException, ServletException {

    PageContext pageContext = null;
    HttpSession session = null;
    ServletContext application = null;
    ServletConfig config = null;
    JspWriter out = null;
    Object page = this;
    JspWriter _jspx_out = null;
    PageContext _jspx_page_context = null;

    try {
      response.setContentType("text/html;charset=UTF-8");
      pageContext = _jspxFactory.getPageContext(this, request, response,
      			null, true, 8192, true);
      _jspx_page_context = pageContext;
      application = pageContext.getServletContext();
      config = pageContext.getServletConfig();
      session = pageContext.getSession();
      out = pageContext.getOut();
      _jspx_out = out;
      _jspx_resourceInjector = (org.glassfish.jsp.api.ResourceInjector) application.getAttribute("com.sun.appserv.jsp.resource.injector");

      out.write("\n");
      out.write("\n");
      out.write("\n");
      out.write("\n");
      out.write("\n");
      out.write("\n");
      out.write("\n");
      out.write("<!DOCTYPE html>\n");
      out.write("<html>\n");
      out.write("    <head>\n");
      out.write("        <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n");
      out.write("        <title>e-social content</title>\n");
      out.write("    </head>\n");
      out.write("    \n");
      out.write("    <body>\n");
      out.write("        \n");
      out.write("        <script>\n");
      out.write("            function myFunction(){ // MÉTODO GET DOS FIELDS\n");
      out.write("                document.getElementById(\"txtNome\").value=val;\n");
      out.write("                document.getElementById(\"txtId\").value=info;\n");
      out.write("            }\n");
      out.write("            function getValueTx(){ // MÉTODO GET DO FIELD\n");
      out.write("                document.getElementById(\"txtNome\").value=infos;\n");
      out.write("            }\n");
      out.write("            function doSubmit() {\n");
      out.write("                //document.forms.action;\n");
      out.write("            }\n");
      out.write("            function novoArquivo(){ // NOVO ARQUIVO\n");
      out.write("                window.open(\"Teste.jsp\",\"e-social content\",windowFeatures);\n");
      out.write("            }\n");
      out.write("            function nova(){ // NOVA PÁGINA\n");
      out.write("                location.href=\" trabalhadores.jsp\";\n");
      out.write("            }\n");
      out.write("            \n");
      out.write("            function outraFunction(){\n");
      out.write("                ");

                    if(1>0){
                        System.out.println("1+1=2");
                    }
                
      out.write("\n");
      out.write("            }\n");
      out.write("            \n");
      out.write("        </script>\n");
      out.write("        \n");
      out.write("        <!-- CÓDIGO JAVA QUE FAZ A CONEXÃO COM A BASE DE DADOS E QUERY-->        \n");
      out.write("        ");

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
        
      out.write("\n");
      out.write("        <!-- CÓDIGO JAVA QUE SETA O VALOR NA INPUT_TEXT -->\n");
      out.write("        ");
 
         //request.setAttribute("nomeInfo", valor);
         String valor="";         
         //String sqlTmp0="SELECT dbo.PPESSOA.Codigo [COD_PESSOA], dbo.PPESSOA.NOME AS [NOME], dbo.PPESSOA.REGPROFISSIONAL [REGPREV] FROM PPESSOA, PFUNC WHERE PPESSOA.NOME='"+request.getParameter("txtNome")+"' AND PPESSOA.CODIGO = PFUNC.CODPESSOA";
         String sqlTmp1="SELECT dbo.PPESSOA.Codigo [COD_PESSOA], dbo.PPESSOA.NOME AS [NOME], dbo.PPESSOA.REGPROFISSIONAL [REGPREV] FROM PPESSOA, PFUNC WHERE PPESSOA.NOME='"+a+"' AND PPESSOA.CODIGO = PFUNC.CODPESSOA";
         pstmt = con.prepareStatement(sqlTmp1);
         reset = pstmt.executeQuery();
         if(reset.next() == true){
          
      out.write(" <p> ");
      out.print(reset.getString("NOME"));
      out.write(' ');
valor=reset.getString("NOME"); javax.swing.JOptionPane.showMessageDialog(null, valor + "El Shaday! Kadosh!");}else{
          javax.swing.JOptionPane.showMessageDialog(null,"Falha na consulta... " + "o nome é " + val.trim() + " Id: " + infos);
          javax.swing.JOptionPane.showMessageDialog(null, "Sem mais índices!");
} 
      out.write(" </p>\n");
      out.write("        \n");
      out.write("        \n");
      out.write("        \n");
      out.write("        <h1>Admissão de Trabalhador</h1>\n");
      out.write("        <form name=\"form1\" method=\"post\" action=\"trabalhadores.jsp\">\n");
      out.write("            \n");
      out.write("            <p> <label id=\"1\" > ID: </label> \n");
      out.write("                <input type=\"text\" id=\"id\"  name=\"txtId\"  size=\"40\" maxlength=\"40\" value=\"");
 out.println(infos); 
      out.write("\">\n");
      out.write("            </p>\n");
      out.write("            \n");
      out.write("            <p> <label id=\"2\" > NOME: </label>\n");
      out.write("               <input type=\"text\" id=\"nome\" name=\"txtInfo\" size=\"40\" maxlength=\"40\" value=\"");
 out.println(val); 
      out.write("\">\n");
      out.write("            </p>\n");
      out.write("            \n");
      out.write("            <p>\n");
      out.write("                <input type=\"button\" name=\"mostrar\" id=\"mostrar\" value=\"Enviar\" onclick=\"novoArquivo()\" >\n");
      out.write("                <input type=\"button\" name=\"trab\" id=\"id2\" value=\"Trabalhadores\" onclick=\"nova()\" >\n");
      out.write("                <input type=\"button\" name=\"trab\" id=\"id2\" value=\"Trabalhadores\" onclick=\"nova()\" >\n");
      out.write("                <>\n");
      out.write("            </p>\n");
      out.write("            \n");
      out.write("        </form>\n");
      out.write("        \n");
      out.write("        <p> &nbsp; </p>\n");
      out.write("        \n");
      out.write("    </body>\n");
      out.write("</html>\n");
    } catch (Throwable t) {
      if (!(t instanceof SkipPageException)){
        out = _jspx_out;
        if (out != null && out.getBufferSize() != 0)
          out.clearBuffer();
        if (_jspx_page_context != null) _jspx_page_context.handlePageException(t);
        else throw new ServletException(t);
      }
    } finally {
      _jspxFactory.releasePageContext(_jspx_page_context);
    }
  }
}