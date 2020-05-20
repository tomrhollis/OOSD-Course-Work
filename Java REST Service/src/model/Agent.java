package model;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the agents database table.
 * 
 */
@Entity
@Table(name="agents")
@NamedQuery(name="Agent.findAll", query="SELECT a FROM Agent a")
public class Agent implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@Column(unique=true, nullable=false)
	@Order(1)
	@Nickname("Agent ID")
	private int agentId;

	@Order(2)
	@Nickname("First Name")
	@Column(length=20)
	private String agtFirstName;
	
	@Order(3)
	@Nickname("Mid Init")
	@Column(length=5)
	private String agtMiddleInitial;

	@Order(4)
	@Nickname("Last Name")
	@Column(length=20)
	private String agtLastName;
	
	@Order(5)
	@Nickname("Position")
	@Column(length=20)
	private String agtPosition;
	
	@Order(6)
	@Nickname("Email")
	@Column(length=50)
	private String agtEmail;

	@Order(7)
	@Nickname("Phone")
	@Column(length=20)
	private String agtBusPhone;

	@Order(8)
	@Nickname("Agency ID")
	private int agencyId;

	@Lob
	private String agtPassword;



	public Agent() {
	}

	public int getAgentId() {
		return this.agentId;
	}

	public void setAgentId(int agentId) {
		this.agentId = agentId;
	}

	public int getAgencyId() {
		return this.agencyId;
	}

	public void setAgencyId(int agencyId) {
		this.agencyId = agencyId;
	}

	public String getAgtBusPhone() {
		return this.agtBusPhone;
	}

	public void setAgtBusPhone(String agtBusPhone) {
		this.agtBusPhone = agtBusPhone;
	}

	public String getAgtEmail() {
		return this.agtEmail;
	}

	public void setAgtEmail(String agtEmail) {
		this.agtEmail = agtEmail;
	}

	public String getAgtFirstName() {
		return this.agtFirstName;
	}

	public void setAgtFirstName(String agtFirstName) {
		this.agtFirstName = agtFirstName;
	}

	public String getAgtLastName() {
		return this.agtLastName;
	}

	public void setAgtLastName(String agtLastName) {
		this.agtLastName = agtLastName;
	}

	public String getAgtMiddleInitial() {
		return this.agtMiddleInitial;
	}

	public void setAgtMiddleInitial(String agtMiddleInitial) {
		this.agtMiddleInitial = agtMiddleInitial;
	}

	public String getAgtPassword() {
		return this.agtPassword;
	}

	public void setAgtPassword(String agtPassword) {
		this.agtPassword = agtPassword;
	}

	public String getAgtPosition() {
		return this.agtPosition;
	}

	public void setAgtPosition(String agtPosition) {
		this.agtPosition = agtPosition;
	}

}