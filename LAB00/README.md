# BÁO CÁO THỰC HÀNH LAB 00

## 1. Thông tin sinh viên
- **Họ và tên:** Nguyễn Phi Long
- **Mã số sinh viên:** 1250080106
- **Email:** 1250080106@sv.hcmunre.edu.vn
- **Tên bài thực hành:** Lab00 - Thiết lập môi trường phát triển (Environment Setup)

---

## 2. Thông tin môi trường & Phiên bản cài đặt
- **Hệ điều hành:** Windows 11 Home 64-bit (OS Build: 26200.9168)
- **Java (JDK):** OpenJDK Temurin 21.0.12.1+1 (LTS)
  - `JAVA_HOME`: `C:\Program Files\Eclipse Adoptium\jdk-21.0.12.101-hotspot`
- **Apache Maven:** Phiên bản 3.9.16
  - `MAVEN_HOME`: `C:\Program Files\Maven\apache-maven-3.9.16`
- **Git:** Git version 2.51.0 / 2.55.0 (Windows)
- **IDE:** IntelliJ IDEA 2026.2 (Community Edition)
  - Plugin đã kích hoạt: `plantuml4idea` (PlantUML Integration)

---

## 3. Nội dung thực hiện
1. **Kiểm tra thông số phần cứng và cấu hình hệ thống:** Xác minh hệ điều hành Windows 11 và dung lượng RAM/CPU.
2. **Cài đặt & Cấu hình Java:** Cài đặt Eclipse Adoptium JDK 21, thiết lập biến môi trường `$env:JAVA_HOME` và kiểm tra lệnh `java -version`, `javac -version`.
3. **Cài đặt & Cấu hình Maven:** Cài đặt Apache Maven 3.9.16, thêm biến môi trường và xác nhận qua lệnh `mvn -version`, `Get-Command mvn`.
4. **Cài đặt & Cấu hình Git:** Kiểm tra phiên bản Git, cấu hình tên người dùng (`user.name`) và email học tập (`user.email`).
5. **Khởi tạo và cấu hình dự án trên IntelliJ IDEA:**
   - Mở dự án mẫu `starter` (`library-ooad-labs`).
   - Thiết lập Project SDK trỏ đúng về `temurin-21`.
   - Cài đặt plugin hỗ trợ thiết kế UML: `plantuml4idea`.
6. **Thực thi và đóng gói ứng dụng:**
   - Chạy thử nghiệm lớp `vn.edu.hcmunre.library.Main`.
   - Sử dụng Maven để build dự án ra file JAR: `library-ooad-labs-1.0.0.jar`.
   - Chạy kiểm thử ứng dụng độc lập qua dòng lệnh `java -jar`.
7. **Lưu vết môi trường & Quản lý phiên bản:**
   - Tạo file lưu baseline môi trường `environment.txt`.
   - Thực hiện commit ban đầu vào Git (`chore: initialize OOAD lab project`).

---

## 4. Kết quả đạt được
- **Chạy trực tiếp từ mã nguồn:** In thành công chuỗi thông báo:
  ```text
  Library OOAD starter project is ready.
  Process finished with exit code 0
