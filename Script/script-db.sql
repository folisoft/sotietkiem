

select * from QuyDinh

delete from QuyDinh;
Insert into QuyDinh(MSQD, Ngay, NoiDung) Values 
(N'QD1', '2019/11/23', N'Có 3 loại tiết kiệm (<b>Không kỳ hạn, 3 tháng, 6 tháng</b>) Số tiền gửi (ban đầu) tối thiếu là 1tr đồng'),
(N'QD2', '2019/11/23', N'Chỉ nhận gửi thêm tiền khi đến <b>kỳ hạn tính lãi suất</b> của các loại tiết kiệm tương ứng. Số tiền gửi thêm tối thiểu là 100k đồng'),
(N'QD3', '2019/11/23', N'Lãi suất là <b>0.15%</b> đối với loại không kỳ hạn, <b>0.5%</b> với kỳ hạn 3 tháng và <b>0.55%</b> với kỳ hạng 6 tháng.<br>
Tiền lãi = số dư * lãi suất * kỳ hạn (số tháng của loại tiết kiệm tương ứng)<br>
Loại tiết kiệm có kỳ hạn chỉ được rút khi quá kỳ hạn và phải rút hết toàn bộ, khi này tiên lãi được tính với mức lãi suất của loại không kỳ hạn.<br>
Loại tiết kiệm không kỳ hạn được rút khi gửi trên 15 ngày và có thể rút số tiền <= số dư hiện có.<br>
Sổ sau khi rút hết tiền sẽ tự động đóng.'),
(N'QD6', '2019/11/23', N'Người dùng có thể thay đổi các quy định như sau:<br><br>
<b>QD1</b>: Thay đổi số lượng các loại kỳ hạn, tiền gửi tối thiểu.<br>
<b>QD3</b>: Thay đổi thời gian gởi tối thiểu và lãi suất các loại kỳ hạn.');

delete from loaitietkiem;
Insert into LoaiTietKiem(TenLoaiTietKiem, LaiSuat, NgayHieuLuc, IsDeleted, KyHan) Values
(N'Không kỳ hạn', '0.15', '2019/11/01', 0, 0),
(N'3 tháng', '0.5', '2019/11/01', 0, 3),
(N'6 tháng', '0.55', '2019/11/01', 0, 6);

delete from DinhMuc;
Insert into DinhMuc(TienGuiLanDauToiThieu) values (1000000);