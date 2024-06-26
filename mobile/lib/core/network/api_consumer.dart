abstract class ApiConsumer{
    Future<dynamic> get(String path,
      {Map<String, dynamic>? queryParameters, String? token});
  Future<dynamic> post(String path,
      {Map<String, dynamic>? body,
      Map<String, dynamic>? queryParameters,
      String? token,
      bool? formDataIsEnabled});
}