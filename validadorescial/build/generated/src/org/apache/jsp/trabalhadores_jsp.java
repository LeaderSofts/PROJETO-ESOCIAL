package org.apache.jsp;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;

public final class trabalhadores_jsp extends org.apache.jasper.runtime.HttpJspBase
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
      out.write("<!DOCTYPE html>\n");
      out.write("<html>\n");
      out.write("    <head>\n");
      out.write("        <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n");
      out.write("        <title>JSP Page</title>\n");
      out.write("    </head>\n");
      out.write("    \n");
      out.write("    <body>\n");
      out.write("        \n");
      out.write("        <script>\n");
      out.write("            function mainPage(){\n");
      out.write("                location.href=\" Teste.jsp\";\n");
      out.write("            }    \n");
      out.write("        </script>    \n");
      out.write("        \n");
      out.write("        \n");
      out.write("        <h1> Lista de trabalhadores</h1>\n");
      out.write("        <form id=\"form1\" name=\"form1\" method=\"post\">  \n");
      out.write("            <table border=\"1\" width=\"200\">\n");
      out.write("                <thead>\n");
      out.write("                    <tr> \n");
      out.write("                     <th> Evento de Cadastro Inicial - Admissão do Trabalhador\n");
      out.write("                      ---------- &nbsp; </th> \n");
      out.write("                    </tr>\n");
      out.write("                       \n");
      out.write("                    <tr>\n");
      out.write("                        <th> Dados do trabalhador </th>\n");
      out.write("                        <th> Preenchimento </th>\n");
      out.write("                        <th> Regra de validação </th>\n");
      out.write("                    </tr>\n");
      out.write("                </thead>\n");
      out.write("                <tbody>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> Matrícula </td>\n");
      out.write("                        <td> Kadosh </td>\n");
      out.write("                        <td> Holly </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                        <td> &nbsp; </td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td></td>\n");
      out.write("                        <td></td>\n");
      out.write("                        <td></td>\n");
      out.write("                    </tr>\n");
      out.write("                    <tr>\n");
      out.write("                        <td></td>\n");
      out.write("                        <td></td>\n");
      out.write("                        <td></td>\n");
      out.write("                    </tr>\n");
      out.write("                </tbody>\n");
      out.write("            </table>\n");
      out.write("\n");
      out.write("        <input type=\"button\" name=\"voltar\" id=\"id1\" value=\"Trabalhadores\" onclick=\"mainPage()\" >\n");
      out.write("        \n");
      out.write("        </form>\n");
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
