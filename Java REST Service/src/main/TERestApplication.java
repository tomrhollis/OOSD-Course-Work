package main;

import java.util.HashSet;
import java.util.Set;

import javax.ws.rs.core.Application;
 

public class TERestApplication  extends Application {
	
	private Set<Object> singletons = new HashSet<Object>();
	 
	public TERestApplication() {
		singletons.add(new TERest());
	}
 
	@Override
	public Set<Object> getSingletons() {
		return singletons;
	}

	@Override
	public Set<Class<?>> getClasses() {
		return null;
	}

}
