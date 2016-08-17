package org.apache.jsp;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;
import java.sql.ResultSet;
import java.sql.PreparedStatement;
import java.sql.Connection;
import java.sql.DriverManager;

public final class trabalhador_jsp extends org.apache.jasper.runtime.HttpJspBase
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

      out.write('\n');
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
      out.write("        <title>JSP Page</title>\n");
      out.write("    </head>\n");
      out.write("    \n");
      out.write("    <body>\n");
      out.write("        <!-- CÓDIGO JAVA QUE FAZ A CONEXÃO COM A BASE DE DADOS E QUERY-->        \n");
      out.write("        ");

         String info = request.getParameter("txtNome");
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
           //javax.swing.JOptionPane.showMessageDialog(null, "1 --- El Shaday! Kadosh!");}else{
           if( i <= 5){
            javax.swing.JOptionPane.showMessageDialog(null,"Nome: " + val);
           }else{
               System.exit(0);
           }
         } 
         String tt="???";
        
      out.write("\n");
      out.write("        <!-- CÓDIGO JAVA QUE SETA O VALOR NA INPUT_TEXT -->\n");
      out.write("        ");
 
         String valor=""; //request.getParameter("txtNome");
         //request.setAttribute("nomeInfo", valor);
         String sql1="SELECT dbo.PPESSOA.Codigo [COD_PESSOA], dbo.PPESSOA.NOME AS [NOME], dbo.PPESSOA.REGPROFISSIONAL"
         +"[REGPREV] FROM PPESSOA, PFUNC WHERE PPESSOA.CODIGO="+request.getParameter("txtNome")+" AND PPESSOA.CODIGO = PFUNC.CODPESSOA";
         pstmt = con.prepareStatement(sql1);
         reset = pstmt.executeQuery();
         if(reset.next() == true){
         
      out.write(' ');
      out.print(reset.getString("NOME"));
      out.write(' ');
valor=reset.getString("NOME"); javax.swing.JOptionPane.showMessageDialog(null, "El Shaday! Kadosh!");}else{
          javax.swing.JOptionPane.showMessageDialog(null, "Não rolou!");
         } 
      out.write(" \n");
      out.write("        \n");
      out.write("        <script>\n");
      out.write("            function myFunction(){\n");
      out.write("                document.getElementById(\"txtNome\").value=tt;\n");
      out.write("            }\n");
      out.write("            function getValueTx(){\n");
      out.write("                document.getElementById(\"txtNome\").value=info;\n");
      out.write("            }\n");
      out.write("        </script>\n");
      out.write("         \n");
      out.write("        \n");
      out.write("        <h1>Admissão de Trabalhador</h1>\n");
      out.write("        <form name=\"form1\" method=\"post\" action=\"trabalhadores.jsp\"> \n");
      out.write("            <p> <!--Seleção: -->\n");
      out.write("               <!-- <label for=\"cbocarreira\"> Select:  </label> -->\n");
      out.write("               <!-- <select name=\"cbocarreira\" id=\"cbocarreira\" value=val> -->\n");
      out.write("                <!--TEXTO JAVA AQUI WHILE... RESET-->\n");
      out.write("                   <!-- request.setAttribute(\"sobreN\", sobreNome); -->\n");
      out.write("                <!-- </select> -->\n");
      out.write("                \n");
      out.write("                <label name=\"lblCodFunc\" width=\"20\" value=\"Matrícula:\" > </label>\n");
      out.write("                <label name=\"lblName\" width=\"20\" value=\"Nome: \" > </label>\n");
      out.write("                <input type=\"text\" id=\"id\"   name=\"txtId\"   width=\"20\" maxlength=\"30\" value=\"Nome*\">\n");
      out.write("                <input type=\"text\" id=\"name\" name=\"txtNome\" width=\"25\" maxlength=\"30\" value=\"Nickname:\" onclick=\"myFunction()\">\n");
      out.write("                \n");
      out.write("                <!-- <input type=\"text\" name=\"nome\" value=\"Josefa Palotes\"> -->\n");
      out.write("                <!-- <input type=\"text\" id=\"name\" name=\"txtNome\" width=\"20\" value=\"Nome:\"> -->\n");
      out.write("            </p> \n");
      out.write("            <!onclick=myfunction() >\n");
      out.write("            <p>\n");
      out.write("                <input type=\"button\" name=\"mostrar\" id=\"mostrar\" value=\"Mostrar\" onclick=\"myFunction()\">\n");
      out.write("            </p>\n");
      out.write("\n");
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
