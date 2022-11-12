
Imports System.Net.Http
Imports Accord.Controls
Imports Accord.Imaging.Filters
Imports Accord.Video.FFMPEG

Public Class Form1
    Dim vidplay As New VideoSourcePlayer
    Dim rtsp As String = "rtsp://192.168.8.102/live/ch00_1"
    Dim ffmpeg As VideoFileSource = New VideoFileSource(rtsp)
    Dim buffer As Bitmap
    Dim stts_cam As Boolean

    Sub run_buffer()
        buffer = vidplay.GetCurrentVideoFrame
        Dim abcdeg As Integer = 200
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = buffer
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not stts_cam Then
            stts_cam = True
            Button1.Text = "ON"
            vidplay.VideoSource = ffmpeg
            vidplay.Start()
            AddHandler Application.Idle, AddressOf run_buffer

        Else
            stts_cam = False
            Button1.Text = "Off"
            vidplay.WaitForStop()
            vidplay.Stop()

        End If
    End Sub

End Class

