require 'rest-client'

module Authorise

  def post_credentials(payload)
    RestClient.post 'https://restful-booker.herokuapp.com/auth', payload, content_type: :json
  rescue => e
    e.to_s
  end

end