Public Class Form1
    Dim soalBersih As String = ""
    Dim soal As String 
    Dim kiri As String = ""
    Dim kanan As String = ""
    Dim hitung As Double
    Sub cekAwal()
        If TBLayar.Text = "0" Then
            TBLayar.Text = ""
        End If
    End Sub
    Function tautologi() As Boolean
        If TBLayar.Text <> "0" And TBLayar.Text.Substring(TBLayar.Text.Length - 1, 1) <> "+" And TBLayar.Text.Substring(TBLayar.Text.Length - 1, 1) <> "-" And TBLayar.Text.Substring(TBLayar.Text.Length - 1, 1) <> "x" And TBLayar.Text.Substring(TBLayar.Text.Length - 1, 1) <> "÷" Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BNol_Click(sender As Object, e As EventArgs) Handles BNol.Click
        cekAwal()
        TBLayar.Text += "0"
    End Sub

    Private Sub BSatu_Click(sender As Object, e As EventArgs) Handles BSatu.Click
        cekAwal()
        TBLayar.Text += "1"
    End Sub

    Private Sub BDua_Click(sender As Object, e As EventArgs) Handles BDua.Click
        cekAwal()
        TBLayar.Text += "2"
    End Sub

    Private Sub BTiga_Click(sender As Object, e As EventArgs) Handles BTiga.Click
        cekAwal()
        TBLayar.Text += "3"
    End Sub

    Private Sub BEmpat_Click(sender As Object, e As EventArgs) Handles BEmpat.Click
        cekAwal()
        TBLayar.Text += "4"
    End Sub

    Private Sub BLima_Click(sender As Object, e As EventArgs) Handles BLima.Click
        cekAwal()
        TBLayar.Text += "5"
    End Sub

    Private Sub BEnam_Click(sender As Object, e As EventArgs) Handles BEnam.Click
        cekAwal()
        TBLayar.Text += "6"
    End Sub

    Private Sub BTujuh_Click(sender As Object, e As EventArgs) Handles BTujuh.Click
        cekAwal()
        TBLayar.Text += "7"
    End Sub

    Private Sub BDelapan_Click(sender As Object, e As EventArgs) Handles BDelapan.Click
        cekAwal()
        TBLayar.Text += "8"
    End Sub

    Private Sub BSembilan_Click(sender As Object, e As EventArgs) Handles BSembilan.Click
        cekAwal()
        TBLayar.Text += "9"
    End Sub

    Private Sub BCe_Click(sender As Object, e As EventArgs) Handles BCe.Click
        If (TBLayar.Text.Length = 1) Then
            TBLayar.Text = "0"
        Else
            TBLayar.Text = TBLayar.Text.Substring(0, TBLayar.Text.Length - 1)
        End If
    End Sub

    Private Sub BAc_Click(sender As Object, e As EventArgs) Handles BAc.Click
        TBLayar.Text = "0"
    End Sub

    Private Sub BTambah_Click(sender As Object, e As EventArgs) Handles BTambah.Click
        If tautologi() Then
            TBLayar.Text += "+"
        End If
    End Sub

    Private Sub BKurang_Click(sender As Object, e As EventArgs) Handles BKurang.Click
        If tautologi() Then
            TBLayar.Text += "-"
        End If
    End Sub

    Private Sub BKali_Click(sender As Object, e As EventArgs) Handles BKali.Click
        If tautologi() Then
            TBLayar.Text += "x"
        End If
    End Sub

    Private Sub BBagi_Click(sender As Object, e As EventArgs) Handles BBagi.Click
        If tautologi() Then
            TBLayar.Text += "÷"
        End If
    End Sub

    Private Sub BSamaDengan_Click(sender As Object, e As EventArgs) Handles BSamaDengan.Click
        soal = TBLayar.Text
        soal = soal.Replace(",", ".")
        hitungHasil()
        TBLayar.Text = soal
    End Sub
    Sub hitungHasil()
        bersihkan()
        Dim l As Integer = soal.Length
        For i As Integer = 0 To l - 1
            soal = soal.Replace(",", ".")
            If i >= l Then
                Exit For
            End If
            If (soal(i) = "+") Then
                hitung = Val(ambilKiri(i)) + Val(ambilKanan(i))

                soal = kiri + hitung.ToString + kanan
                i = 0
                l = soal.Length
                Debug.WriteLine("soal : " + soal)
            ElseIf soal(i) = "-" Then
                hitung = Val(ambilKiri(i)) - Val(ambilKanan(i))

                soal = kiri + hitung.ToString + kanan
                i = 0
                l = soal.Length
            End If
        Next

    End Sub
    Function ambilKiri(index As Integer) As String
        Dim i As Integer = 0
        For i = index - 1 To 0 Step -1
            If (soal(i) = "x" Or soal(i) = "÷" Or soal(i) = "+" Or soal(i) = "-") Then
                i += 1
                Exit For
            End If
        Next
        If i < 0 Then
            i = 0
        End If

        kiri = soal.Substring(0, i)
        Return soal.Substring(i, index - i)
    End Function
    Function ambilKanan(index As Integer) As String
        Dim i As Integer = 0
        Dim panjang = soal.Length
        Dim z As Integer = 1
        For i = index + 1 To panjang - 1 Step 1
            If (soal(i) = "x" Or soal(i) = "÷" Or soal(i) = "+" Or soal(i) = "-") Then
                z -= 1
                Exit For
            End If
        Next
        If i > panjang - 1 Then
            i = panjang - 1
        End If
        Debug.WriteLine("index : " + index.ToString)
        Debug.WriteLine("i : " + i.ToString)
        Debug.WriteLine("panjang : " + panjang.ToString)

        kanan = soal.Substring(i, panjang - i - z)

        Return soal.Substring(index + 1, i - index)

    End Function
    Sub bersihkan()
        Dim l As Integer = soal.Length
        For i As Integer = 0 To l - 1
            soal = soal.Replace(",", ".")
            Debug.WriteLine("soal repl = " + soal)
            If i >= l Then
                Exit For
            End If
            If (soal(i) = "÷") Then

                hitung = Val(ambilKiri(i)) / Val(ambilKanan(i))

                soal = kiri + hitung.ToString + kanan
                i = 0
                l = soal.Length
                Debug.WriteLine("soal : " + soal)
            ElseIf soal(i) = "x" Then
                hitung = Val(ambilKiri(i)) * Val(ambilKanan(i))

                soal = kiri + hitung.ToString + kanan
                i = 0
                l = soal.Length

                Debug.WriteLine("soal : " + soal)
            End If
        Next
    End Sub
End Class
