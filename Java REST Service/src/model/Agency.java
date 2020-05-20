package model;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the agencies database table.
 * 
 */
@Entity
@Table(name="agencies")
@NamedQuery(name="Agency.findAll", query="SELECT a FROM Agency a")
public class Agency implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@Column(unique=true, nullable=false)
	@Order(1)
	@Nickname("Agency ID")
	private int agencyId;

	@Order(2)
	@Nickname("Address")
	@Column(length=50)
	private String agncyAddress;

	@Order(3)
	@Nickname("City")
	@Column(length=50)
	private String agncyCity;
	
	@Order(4)
	@Nickname("Province")
	@Column(length=50)
	private String agncyProv;

	@Order(5)
	@Nickname("Postal Code")
	@Column(length=50)
	private String agncyPostal;
	
	@Order(6)
	@Nickname("Country")
	@Column(length=50)
	private String agncyCountry;

	@Order(7)
	@Nickname("Phone #")
	@Column(length=50)
	private String agncyPhone;
	
	@Order(8)
	@Nickname("Fax #")
	@Column(length=50)
	private String agncyFax;

	public Agency() {
	}

	public int getAgencyId() {
		return this.agencyId;
	}

	public void setAgencyId(int agencyId) {
		this.agencyId = agencyId;
	}

	public String getAgncyAddress() {
		return this.agncyAddress;
	}

	public void setAgncyAddress(String agncyAddress) {
		this.agncyAddress = agncyAddress;
	}

	public String getAgncyCity() {
		return this.agncyCity;
	}

	public void setAgncyCity(String agncyCity) {
		this.agncyCity = agncyCity;
	}

	public String getAgncyCountry() {
		return this.agncyCountry;
	}

	public void setAgncyCountry(String agncyCountry) {
		this.agncyCountry = agncyCountry;
	}

	public String getAgncyFax() {
		return this.agncyFax;
	}

	public void setAgncyFax(String agncyFax) {
		this.agncyFax = agncyFax;
	}

	public String getAgncyPhone() {
		return this.agncyPhone;
	}

	public void setAgncyPhone(String agncyPhone) {
		this.agncyPhone = agncyPhone;
	}

	public String getAgncyPostal() {
		return this.agncyPostal;
	}

	public void setAgncyPostal(String agncyPostal) {
		this.agncyPostal = agncyPostal;
	}

	public String getAgncyProv() {
		return this.agncyProv;
	}

	public void setAgncyProv(String agncyProv) {
		this.agncyProv = agncyProv;
	}

}