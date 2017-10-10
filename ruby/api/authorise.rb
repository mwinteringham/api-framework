require 'rest-client'

module Authorise

  def post_credentials(payload)
    begin
      return RestClient.post 'https://restful-booker.herokuapp.com/auth', payload, :content_type => :json
    rescue => e
      return e.to_s
    end
  end

end