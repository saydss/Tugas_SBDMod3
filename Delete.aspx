<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="mod3_kel16_sbd_.Delete" EnableEventValidation = "false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>matakuliah</h3>
            <asp:GridView ID="gvmatakuliah" runat="server" DataKeyNames="id_matakuliah,nama_matakuliah,id_ruangan" OnRowDataBound="gvmatakuliah_RowDataBound" OnSelectedIndexChanged="gvmatakuliah_SelectedIndexChanged" >
            </asp:GridView>
            <h3>mahasiswa</h3>
            <asp:GridView ID="gvmahasiswa" runat="server" DataKeyNames="nim,nama_mahasiswa,domisili,id_matakuliah" OnRowDataBound="gvmahasiswa_RowDataBound" OnSelectedIndexChanged="gvmahasiswa_SelectedIndexChanged" >
            </asp:GridView>
            <h3>dosen</h3>
            <asp:GridView ID="gvdosen" runat="server" DataKeyNames="nip,nama_dosen,domisili,id_matakuliah" OnRowDataBound="gvdosen_RowDataBound" OnSelectedIndexChanged="gvdosen_SelectedIndexChanged">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
