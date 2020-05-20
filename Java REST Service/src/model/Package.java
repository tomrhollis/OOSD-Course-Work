package model;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.util.Date;


/**
 * The persistent class for the packages database table.
 * 
 */
@Entity
@Table(name="packages")
@NamedQuery(name="Package.findAll", query="SELECT p FROM Package p")
public class Package implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@Column(unique=true, nullable=false)
	@Order(1)
	@Nickname("Package ID")
	private int packageId;

	@Column(nullable=false, length=50)
	@Order(2)
	@Nickname("Name")
	private String pkgName;
	
	@Column(length=50)
	@Order(3)
	@Nickname("Description")
	private String pkgDesc;

	@Temporal(TemporalType.TIMESTAMP)
	@Order(4)
	@Nickname("Start Date")
	private Date pkgStartDate;

	@Temporal(TemporalType.TIMESTAMP)
	@Order(5)
	@Nickname("End Date")
	private Date pkgEndDate;

	@Column(nullable=false, precision=10, scale=4)
	@Order(6)
	@Nickname("Base Price")
	private BigDecimal pkgBasePrice;

	@Column(precision=10, scale=4)
	@Order(7)
	@Nickname("Commission")
	private BigDecimal pkgAgencyCommission;


	public Package() {
	}

	public int getPackageId() {
		return this.packageId;
	}

	public void setPackageId(int packageId) {
		this.packageId = packageId;
	}

	public BigDecimal getPkgAgencyCommission() {
		return this.pkgAgencyCommission;
	}

	public void setPkgAgencyCommission(BigDecimal pkgAgencyCommission) {
		this.pkgAgencyCommission = pkgAgencyCommission;
	}

	public BigDecimal getPkgBasePrice() {
		return this.pkgBasePrice;
	}

	public void setPkgBasePrice(BigDecimal pkgBasePrice) {
		this.pkgBasePrice = pkgBasePrice;
	}

	public String getPkgDesc() {
		return this.pkgDesc;
	}

	public void setPkgDesc(String pkgDesc) {
		this.pkgDesc = pkgDesc;
	}

	public Date getPkgEndDate() {
		return this.pkgEndDate;
	}

	public void setPkgEndDate(Date pkgEndDate) {
		this.pkgEndDate = pkgEndDate;
	}

	public String getPkgName() {
		return this.pkgName;
	}

	public void setPkgName(String pkgName) {
		this.pkgName = pkgName;
	}

	public Date getPkgStartDate() {
		return this.pkgStartDate;
	}

	public void setPkgStartDate(Date pkgStartDate) {
		this.pkgStartDate = pkgStartDate;
	}

}