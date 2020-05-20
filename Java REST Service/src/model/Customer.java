package model;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the customers database table.
 * 
 */
@Entity
@Table(name="customers")
@NamedQuery(name="Customer.findAll", query="SELECT c FROM Customer c")
public class Customer implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@Column(unique=true, nullable=false)
	@Order(1)
	@Nickname("Customer ID")
	private int customerId;

	@Column(nullable=false, length=25)
	@Order(2)
	@Nickname("First Name")
	private String custFirstName;
	
	@Column(nullable=false, length=25)
	@Order(3)
	@Nickname("Last Name")
	private String custLastName;
	
	@Column(nullable=false, length=50)
	@Order(4)
	@Nickname("Email")
	private String custEmail;

	@Column(length=20)
	@Order(5)
	@Nickname("Home Phone")
	private String custHomePhone;

	@Column(nullable=false, length=20)
	@Order(6)
	@Nickname("Work Phone")
	private String custBusPhone;

	@Column(nullable=false, length=75)
	@Order(7)
	@Nickname("Address")
	private String custAddress;
	
	@Column(nullable=false, length=50)
	@Order(8)
	@Nickname("City")
	private String custCity;
	
	@Column(nullable=false, length=2)
	@Order(9)
	@Nickname("Province")
	private String custProv;

	@Column(nullable=false, length=7)
	@Order(10)
	@Nickname("Postal Code")
	private String custPostal;

	@Column(length=25)
	@Order(11)
	@Nickname("Country")
	private String custCountry;

	@Order(12)
	@Nickname("Agent ID")
	private int agentId;

	@Column(length=20)
	@Order(13)
	@Nickname("Username")
	private String custUsername;
	
	@Column(length=128)
	private String custPassword;

	public Customer() {
	}

	public int getCustomerId() {
		return this.customerId;
	}

	public void setCustomerId(int customerId) {
		this.customerId = customerId;
	}

	public int getAgentId() {
		return this.agentId;
	}

	public void setAgentId(int agentId) {
		this.agentId = agentId;
	}

	public String getCustAddress() {
		return this.custAddress;
	}

	public void setCustAddress(String custAddress) {
		this.custAddress = custAddress;
	}

	public String getCustBusPhone() {
		return this.custBusPhone;
	}

	public void setCustBusPhone(String custBusPhone) {
		this.custBusPhone = custBusPhone;
	}

	public String getCustCity() {
		return this.custCity;
	}

	public void setCustCity(String custCity) {
		this.custCity = custCity;
	}

	public String getCustCountry() {
		return this.custCountry;
	}

	public void setCustCountry(String custCountry) {
		this.custCountry = custCountry;
	}

	public String getCustEmail() {
		return this.custEmail;
	}

	public void setCustEmail(String custEmail) {
		this.custEmail = custEmail;
	}

	public String getCustFirstName() {
		return this.custFirstName;
	}

	public void setCustFirstName(String custFirstName) {
		this.custFirstName = custFirstName;
	}

	public String getCustHomePhone() {
		return this.custHomePhone;
	}

	public void setCustHomePhone(String custHomePhone) {
		this.custHomePhone = custHomePhone;
	}

	public String getCustLastName() {
		return this.custLastName;
	}

	public void setCustLastName(String custLastName) {
		this.custLastName = custLastName;
	}

	public String getCustPassword() {
		return this.custPassword;
	}

	public void setCustPassword(String custPassword) {
		this.custPassword = custPassword;
	}

	public String getCustPostal() {
		return this.custPostal;
	}

	public void setCustPostal(String custPostal) {
		this.custPostal = custPostal;
	}

	public String getCustProv() {
		return this.custProv;
	}

	public void setCustProv(String custProv) {
		this.custProv = custProv;
	}

	public String getCustUsername() {
		return this.custUsername;
	}

	public void setCustUsername(String custUsername) {
		this.custUsername = custUsername;
	}

}