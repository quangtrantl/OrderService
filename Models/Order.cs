﻿namespace OrderService.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
public Order(int Id, int UserId, int BookId)
    {
        Id = Id;
        UserId = UserId;
        BookId = BookId;
    }
}

