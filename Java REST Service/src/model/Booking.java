package model;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the bookings database table.
 * 
 */
@Entity
@Table(name="bookings")
@NamedQuery(name="Booking.findAll", query="SELECT b FROM Booking b")
public class Booking implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@Column(unique=true, nullable=false)
	@Order(1)
	@Nickname("Booking ID")
	private int bookingId;

	@Column(length=50)
	@Order(2)
	@Nickname("Booking #")
	private String bookingNo;

	@Temporal(TemporalType.TIMESTAMP)
	@Order(3)
	@Nickname("Date")
	private Date bookingDate;

	@Order(4)
	@Nickname("Package ID")
	private int packageId;

	@Order(5)
	@Nickname("Customer ID")
	private int customerId;

	@Order(6)
	@Nickname("# of Travelers")
	private double travelerCount;

	@Column(length=1)
	@Order(7)
	@Nickname("Trip Type")
	private String tripTypeId;

	public Booking() {
	}

	public int getBookingId() {
		return this.bookingId;
	}

	public void setBookingId(int bookingId) {
		this.bookingId = bookingId;
	}

	public Date getBookingDate() {
		return this.bookingDate;
	}

	public void setBookingDate(Date bookingDate) {
		this.bookingDate = bookingDate;
	}

	public String getBookingNo() {
		return this.bookingNo;
	}

	public void setBookingNo(String bookingNo) {
		this.bookingNo = bookingNo;
	}

	public int getCustomerId() {
		return this.customerId;
	}

	public void setCustomerId(int customerId) {
		this.customerId = customerId;
	}

	public int getPackageId() {
		return this.packageId;
	}

	public void setPackageId(int packageId) {
		this.packageId = packageId;
	}

	public double getTravelerCount() {
		return this.travelerCount;
	}

	public void setTravelerCount(double travelerCount) {
		this.travelerCount = travelerCount;
	}

	public String getTripTypeId() {
		return this.tripTypeId;
	}

	public void setTripTypeId(String tripTypeId) {
		this.tripTypeId = tripTypeId;
	}

}