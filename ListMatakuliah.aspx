<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListMatakuliah.aspx.cs" Inherits="mod3_kel16_sbd_.ListMatakuliah" enableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="btnmahasiswa" runat="server" PostBackUrl="mahasiswa.aspx"><span style="margin-right: 30px;">mahasiswa</span></asp:LinkButton>
            <asp:LinkButton  ID="btndosen" runat="server" PostBackUrl="dosen.aspx"><span style="margin-right: 30px;">dosen</span></asp:LinkButton>
            <asp:LinkButton ID="btndeleted" runat="server" PostBackUrl="Delete.aspx"><span style="margin-right: 30px;">deleted</span></asp:LinkButton>
            <table>
                <tr>
                    <td>id_matakuliah :</td>
                    <td>
                        <asp:TextBox ID="txtid_matakuliah"
                            runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>nama_matakuliah :</td>
                    <td>
                        <asp:TextBox ID="txtnama_matakuliah"
                            runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>id_ruangan :</td>
                    <td>
                        <asp:TextBox ID="txtid_ruangan"
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
        <asp:GridView ID="GridViewJoin" runat="server" DataKeyNames="id_matakuliah,nama_matakuliah,id_ruangan" OnRowDataBound="GridViewJoin_RowDataBound" OnSelectedIndexChanged="GridViewJoin_SelectedIndexChanged">
        </asp:GridView>
        <h2>Jadwal</h2>
        <asp:GridView ID="gvdosen" runat="server" DataKeyNames="nama_dosen,nama_mahasiswa,nama_matakuliah,id_matakuliah" OnRowDataBound="GridViewJoin_RowDataBound" OnSelectedIndexChanged="GridViewJoin_SelectedIndexChanged">
        </asp:GridView>
    </form>
</body>
</html>
