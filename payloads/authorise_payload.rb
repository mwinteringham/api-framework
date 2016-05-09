class AuthorisePayload

  attr_accessor :username, :password

  def initialize(&block)
    instance_eval &block if block_given?
  end

  def toJson
    return "{
        \"username\": \"#{username}\",
        \"password\": \"#{password}\"
    }"
  end

end