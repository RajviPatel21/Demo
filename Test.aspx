<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        function EditColor(colorId, colorName) {
            document.getElementById('<%= hdnColorId.ClientID %>').value = colorId;
            if (colorId != null) {
                document.getElementById('<%= txtColorName.ClientID %>').value = colorName;
            }
            else {
                return false;
            }
        }       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:UpdatePanel ID="upPartyMaster" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnColorId" runat="server" />
                                    <label>
                                        Color Name</label>
                                    <asp:TextBox ID="txtColorName" runat="server" placeholder="Color Name"></asp:TextBox>
                                </div>
                            </div>
                            
                                    <asp:LinkButton ID="lbtnSubmit" runat="server" OnClick="btnSubmit_Click"><i class="fa fa-check-circle pad-r5"></i>Submit</asp:LinkButton>
                                    <asp:LinkButton ID="lbtnReset" runat="server" OnClick="btnCancel_Click"><i class="fa fa-refresh pad-r5"></i>Reset</asp:LinkButton>
                                </div>
                            </div>
                       
                    </div>
                </div>
                
                                        <table width="100%">
                                            <tr>
                                                <th>
                                                    <label>
                                                        Color Number</label>
                                                </th>
                                                <th>
                                                    <label>
                                                        Color</label>
                                                </th>
                                                <th>
                                                    <label class="clLabel">
                                                        Operation</label>
                                                </th>
                                            </tr>
                                            <asp:Repeater runat="server" ID="repColorDetails">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <span >
                                                                <%# Eval("colorId")%></span>
                                                        </td>
                                                        <td>
                                                            <span >
                                                                <%# Eval("colorName")%></span>
                                                        </td>
                                                        <td>
                                                            <span >
                                                                <asp:LinkButton ID="lbtnEdit" runat="server" CausesValidation="false" title="Edit"
                                                                   OnClientClick='<%# "javascript:return EditColor(" + Eval("colorId") +",\""+Eval("colorName")+"\");" %>'><i class="fa fa-edit pad-r5"></i></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkDelete" runat="server" class="btn-edit mar-l10" title="Delete"
                                                                    CommandName="delete" OnClientClick='javascript:return confirm("Are you sure you want to delete?")'
                                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "colorId") %>'></asp:LinkButton>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
