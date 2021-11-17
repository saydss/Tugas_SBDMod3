<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dosen.aspx.cs" Inherits="mod3_kel16_sbd_.dosen" enableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>nip :</td>
                    <td>
                        <asp:TextBox ID="txtnip"
                            runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>nama_dosen :</td>
                    <td>
                        <asp:TextBox ID="txtnama_dosen"
                            runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>domisili :</td>
                    <td>
                        <asp:TextBox ID="txtdomisili"
                            runat="server"></asp:TextBox></td>

                </tr>
                <tr>
                    <td>id_matakuliah :</td>
                    <td>
                        <asp:TextBox ID="txtid_matakuliah"
                            runat="server"></asp:TextBox></td>

                </tr>
                <tr>
                    <td></td>
                    <td>

                        <asp:Button ID="btnAdd" runat="server"
                            Text="ADD" OnClick="btnAdd_Click" />

                        <asp:Button ID="btnDelete" runat="server"
                            Text="DELETE" OnClick="btnDelete_Click" />

                        <asp:Button ID="btnUpdate" runat="server"
                            Text="UPDATE" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnClear" runat="server"
                            Text="CLEAR" OnClick="btnClear_Click" />

                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="GridViewJoin" runat="server" DataKeyNames="nip,nama_dosen,domisili,id_matakuliah" OnRowDataBound="GridViewJoin_RowDataBound" OnSelectedIndexChanged="GridViewJoin_SelectedIndexChanged">
        </asp:GridView>
    </form>
</body>
</html>