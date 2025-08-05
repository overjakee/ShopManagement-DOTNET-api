namespace ShopManagement_api.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        // ดูรายการคำสั่งซื้อทั้งหมดตาม filtter
        // ดูรายการคำสั่งซื้อของ User 
        // ดูรายละเอียดคำสั่งซื้อของ User ตามรหัสคำสั่งซื้อ
        // เพิ่มคำสั่งซื้อ 
        // แก้ไขคำสั่งซื้อ (เปลี่ยนสถานะการสั่งซื้อ admin)
        // ลบคำสั่งซื้อ (ลบข้อมูลสำหรับ User ลบรายการ)
        // พิมพ์ใบเสร็จรับเงิน (สำหรับ User,Admin)
    }
}
