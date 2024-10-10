public interface IRoomBooking
{
    void BookRoom(Room room, Customer customer, DateTime checkOutDate);
    void ReleaseRoom(Room room);
}
