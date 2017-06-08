package restfulbooker;

import com.intuit.karate.junit4.Karate;
import cucumber.api.CucumberOptions;
import org.junit.runner.RunWith;

@RunWith(Karate.class)
@CucumberOptions(plugin = {"pretty", "html:target/cucumber"})
public class ApiTest {
    
}
