require 'rest-client'

module Authorise

  def post_credentials(payload)
    begin
      return RestClient.post 'http://localhost:3001/auth', payload, :content_type => :json
    rescue => e
      return e.to_s
    end
  end

end