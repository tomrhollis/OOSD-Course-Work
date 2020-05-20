package main;

import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.DELETE;
import javax.ws.rs.Produces;

import java.lang.annotation.Annotation;
import java.lang.reflect.Field;
import java.lang.reflect.InvocationTargetException;
import java.util.ArrayList;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import javax.ws.rs.Consumes;
import javax.ws.rs.core.MediaType;

import com.google.gson.Gson;

import model.Nickname;
import model.Order;

/*
 * TRAVEL EXPERTS REST SERVICE
 * 
 * Serves out JSON objects for travel experts database objects
 * Used by the internal web page and the Travel Experts Android app
 * 
 * Primary Author: Tom Hollis
 * April/May 2020
 * 
 */


@Path("/TERest")
public class TERest {
	
	private static EntityManagerFactory factory;
	private static ArrayList<String> validClasses = new ArrayList<String>();
	
	
	public TERest(){		
		// add certain classes to the whitelist of accessible classes			
		validClasses.add("Customer");
		validClasses.add("Booking");
		validClasses.add("Bookingdetail");
		validClasses.add("Agency");
		validClasses.add("Agent");
		validClasses.add("Package");	
	}
	
	
	// convert the string class name to a Class object for use in the generic function
	private Class<?> getClassObj(String type) { 
		
		if (!validClasses.contains(type)) { // check against list of legit class names for security
			return null;
		}
		
		// can convert that into a class object
		Class<?> c = null;
		
		try {
			c = Class.forName("model." + type);
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return c;
	}
		
	
	// GET the metadata for a record type
	@GET
	@Path("/{ type }/meta")
	@Produces(MediaType.TEXT_PLAIN)
	public String getMeta(@PathParam("type") String type) {
		
		try {
			return getMeta(getClassObj(type).getDeclaredConstructor().newInstance());
		} catch (InstantiationException | IllegalAccessException | IllegalArgumentException | InvocationTargetException
				| NoSuchMethodException | SecurityException e) {
			// TODO Auto-generated catch block
			return e.getMessage();
		}
		
	}
	
	// generic method to find the order and human readable names for a data type's fields
	private <T> String getMeta(T t) {
		
		String json = "[";
		
		Class<? extends Object> c = t.getClass();
		Field [] fields = c.getDeclaredFields();
		
		Order o;
		Nickname n;
		
		for (Field f: fields) {
			
			try {
			
				if (json.length() > 1) {
					json += ",";
				}
				
				o = f.getAnnotation(Order.class);
				n = f.getAnnotation(Nickname.class);
				json += "{\"order\":"+o.value()+",\"dbname\":\""+f.getName()+"\",\"nickname\":\""+n.value()+"\"}";
			} catch (NullPointerException npe) {
				continue;
			}
		}
		json = json.replaceAll("[,]$", "");
		json += "]";
		return json;
	}
	
	
	
	// GET a single record - catch the request and pass it to the generic method
	@GET
	@Path("/{ type }/{ id }")
    @Produces(MediaType.APPLICATION_JSON)
	public String getSomething(@PathParam("type") String type, @PathParam("id") int id) {	

		try {
			return getSomething(getClassObj(type).getDeclaredConstructor().newInstance(), id);
		} catch (InstantiationException | IllegalAccessException | IllegalArgumentException | InvocationTargetException
				| NoSuchMethodException | SecurityException e) {
			// TODO Auto-generated catch block
			return "{" + e.getClass() + ": " + e.getMessage() + "}";
		}		
	}
	
	// Generic method for finding a single record
	private <T> String getSomething(T c, int id) {
		
		factory = Persistence.createEntityManagerFactory("TEWeb");
		EntityManager em = factory.createEntityManager();
		
		T thing=null;
		thing = (T) em.find(c.getClass(), id);
		

		Gson gson = new Gson();
		return gson.toJson(thing);
		
	}
	
	// GET all records - catch the request and pass it to the generic method
	@GET
	@Path("/{ type }")
	@Produces(MediaType.APPLICATION_JSON)
	public String getAllSomething(@PathParam("type") String type) {
		
		try {
			return getAllSomething(getClassObj(type).getDeclaredConstructor().newInstance(), type);
		} catch (InstantiationException | IllegalAccessException | IllegalArgumentException | InvocationTargetException
				| NoSuchMethodException | SecurityException e) {
			// TODO Auto-generated catch block
			return "{" + e.getClass() + ": " + e.getMessage() + "}";
		}
	}
	
	// Generic method for finding all records of a class
	private <T> String getAllSomething(T classType, String type) {
		
		factory = Persistence.createEntityManagerFactory("TEWeb");
		EntityManager em = factory.createEntityManager();
		
		Query q = em.createQuery("select a from " + type + " a");
		List<T> list = q.getResultList();	
		
		Gson gson = new Gson();
		return gson.toJson(list);			
	}
	

    // Catch the POST request to update a record of a specific type, send to generic update method
	@POST
	@Path("/{ type }")
    @Produces(MediaType.TEXT_PLAIN)
	@Consumes(MediaType.APPLICATION_JSON)
	public String postSomething(String json, @PathParam("type") String type) {
		
		try {
			return postPutSomething(getClassObj(type).getDeclaredConstructor().newInstance(), json, "POST");
		} catch (InstantiationException | IllegalAccessException | IllegalArgumentException | InvocationTargetException
				| NoSuchMethodException | SecurityException e) {
			// TODO Auto-generated catch block
			return e.getMessage();
		}
	}

	// Catch the PUT request to add a record of a specific type, send to generic update method
	@PUT
	@Path("/{ type }")
    @Produces(MediaType.TEXT_PLAIN)
	@Consumes(MediaType.APPLICATION_JSON)
	public String putSomething(String json, @PathParam("type") String type) {
		
		try {
			return postPutSomething(getClassObj(type).getDeclaredConstructor().newInstance(), json, "PUT");
		} catch (InstantiationException | IllegalAccessException | IllegalArgumentException | InvocationTargetException
				| NoSuchMethodException | SecurityException e) {
			// TODO Auto-generated catch block
			return e.getMessage();
		}
	}

	// Generic method for adding or updating a record
	private <T> String postPutSomething(T c, String json, String op) {
		factory = Persistence.createEntityManagerFactory("TEWeb");
		EntityManager em = factory.createEntityManager();
		System.out.println(json);
		Gson gson = new Gson();
		//Type t = new TypeToken<T>() {}.getType();
		T row=null;
		row = (T) gson.fromJson(json, c.getClass());
		//TODO: transaction confirmation / rollback if problem
		em.getTransaction().begin();
		
		switch (op) {
		case "POST":
			em.merge(row);
			break;
		case "PUT":
			em.persist(row);
			break;
		}
		
		em.getTransaction().commit();		
				
		em.close();
		factory.close();
		return "Updated";
	}
	

	// Catch requests to DELETE a specific record, pass to generic delete method
	@DELETE
	@Path("/{ type }/{ id }")
	public void deleteSomething(@PathParam("type") String type, @PathParam("id") int id) {
		
		try {
			deleteSomething(getClassObj(type).getDeclaredConstructor().newInstance(), id);
		} catch (InstantiationException | IllegalAccessException | IllegalArgumentException | InvocationTargetException
				| NoSuchMethodException | SecurityException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	}
	
	// Generic method for deleting a record
	private <T> void deleteSomething(T c, int id) {
		factory = Persistence.createEntityManagerFactory("TEWeb");
		EntityManager em = factory.createEntityManager();
		
		T row=null;
		row = (T) em.find(c.getClass(), id);
				
		em.getTransaction().begin();
		em.remove(row);
		em.getTransaction().commit();
		
		em.close();
		factory.close();
	}

	
	
	
}
