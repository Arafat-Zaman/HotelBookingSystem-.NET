public class Room
{
    public int Id { get; set; }
    public string RoomType { get; set; }
    public bool IsAvailable { get; set; }  // Public set accessor
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }

    public Room(string roomType)
    {
        RoomType = roomType;
    }

    public void BookRoom()
    {
        if (IsAvailable)
            IsAvailable = false;
        else
            throw new InvalidOperationException("Room is already booked.");
    }

    public void ReleaseRoom()
    {
        IsAvailable = true;
    }
}
